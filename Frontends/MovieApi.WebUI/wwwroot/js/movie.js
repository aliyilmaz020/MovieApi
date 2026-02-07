let movieId = null;
let modalMode = 'create';
let row = '';
function openModal() {
    modalMode = 'create';
    movieId = null;
    document.getElementById('filmModal').classList.add('show');
    document.getElementById('modalTitle').textContent = 'Yeni Film Ekle';
    document.getElementById('btnSaveOrEdit').textContent = 'Kaydet';
    clearForm();
}
async function editFilm(id) {
    modalMode = 'edit';
    movieId = id;
    document.getElementById('filmModal').classList.add('show');
    document.getElementById('modalTitle').textContent = 'Film Düzenle';
    document.getElementById('btnSaveOrEdit').textContent = 'Güncelle';

    // Film verilerini yükle (örnek)
    let film = await getFilm(id);

    if (film) {
        document.getElementById('filmTitle').value = film.title;
        document.getElementById('filmCreatedYear').value = film.createdYear;
        document.getElementById('filmDuration').value = film.duration;
        document.getElementById('filmRating').value = film.rating;
        document.getElementById('filmCoverImageUrl').value = film.coverImageUrl;
        document.getElementById('filmReleaseDate').value = film.releaseDate;
        document.getElementById('filmDescription').value = film.description;
    }
}
async function saveFilm() {
    const filmName = document.getElementById('filmTitle').value;
    if (!filmName) {
        alert('Lütfen film adını girin!');
        return;
    }

    if (modalMode === 'create') {
        let movie = {
            title: $('#filmTitle').val(),
            createdYear: $('#filmCreatedYear').val(),
            duration: $('#filmDuration').val(),
            rating: $('#filmRating').val(),
            coverImageUrl: $('#filmCoverImageUrl').val(),
            releaseDate: $('#filmReleaseDate').val(),
            description: $('#filmDescription').val(),
            status: false
        };
        await createMovie(movie)
    } else {
        let movie = {
            movieId: movieId,
            title: $('#filmTitle').val(),
            createdYear: $('#filmCreatedYear').val(),
            duration: $('#filmDuration').val(),
            rating: $('#filmRating').val(),
            coverImageUrl: $('#filmCoverImageUrl').val(),
            releaseDate: $('#filmReleaseDate').val(),
            description: $('#filmDescription').val(),
            status: false
        }
        await updateMovie(movie);
    }
    await getFilms()
    closeModal();
}
async function createMovie(movie) {
    const response = await fetch("/Admin/Movie/CreateMovie", {
        method: "POST",
        headers: {
            'Content-Type': "application/json; charset=utf-8;"
        },
        body: JSON.stringify(movie)
    });
    if (response.ok) {
        toastr("Başarılı", "Ekleme İşlemi Başarılı");
    } else {
        toastr("Başarısız", "Ekleme İşlemi Başarısız")
    }
    row = '';
}
async function updateMovie(movie) {
    const response = await fetch("/Admin/Movie/UpdateMovie", {
        method: "POST",
        headers: {
            'Content-Type': "application/json; charset=utf-8;"
        },
        body: JSON.stringify(movie)
    })
    if (response.ok) {
        toastr("Başarılı", "Güncelleme Başarılı");
    } else {
        toastr("Başarısız", "Güncelleme Başarısız");
    }
    row = '';
}
function closeModal() {
    document.getElementById('filmModal').classList.remove('show');
    clearForm();
}

function clearForm() {
    $('.modal-body').find('input, textarea').val('');
}
async function getFilm(id) {
    const response = await fetch(`/Admin/Movie/GetMovie?id=${id}`, {
        method: "POST",
        headers: {
            'Content-Type': "application/json"
        }
    })
    const data = JSON.parse(await response.json());
    return data;
}
function deleteFilm(id, title) {
    document.getElementById('deleteFilmName').textContent = title;
    document.getElementById('deleteModal').classList.add('show');
    movieId = id;
}

function closeDeleteModal() {
    document.getElementById('deleteModal').classList.remove('show');
    deleteFilmId = null;
}

async function confirmDelete() {
    if (movieId) {
        const response = await fetch(`/Admin/Movie/RemoveMovie?id=${movieId}`, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            }
        });
        let data = await response.json();
        if (data === 'true') {
            setTimeout(() => {
                toastr('Başarılı', 'Silme İşlemi Başarılı');
            }, 5000);
            row = '';
            await getFilms();
            closeDeleteModal();
        } else {
            setTimeout(() => {
                toastr('Hata', 'Silme İşlemi Başarısız.');
            }, 5000);
        }

    }
}
function filterFilms() {
    const searchTerm = document.getElementById('searchInput').value;
    const category = document.getElementById('categoryFilter').value;
    const status = document.getElementById('statusFilter').value;

    console.log('Arama:', searchTerm, 'Kategori:', category, 'Durum:', status);
    // Buraya filtreleme kodu gelecek
}
async function getFilms() {
    const response = await fetch('/Admin/Movie/MovieList', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=utf-8'
        }
    });
    const data = await response.json()
    if (response.ok) {
        const films = JSON.parse(data);
        films.forEach(value => {
            fillFilmsTable(value);
        });
    }
    else {
        console.error('Filmler alınamadı:', response.statusText);
    }
}
function fillFilmsTable(film) {
    row += `<tr> 
                    <td><img src="${film.coverImageUrl}" alt="Poster" class="film-poster"></td>
                    <td><strong>${film.title}</strong></td>
                    <td>${film.createdYear}</td>
                    <td>${film.duration} dk</td>
                    <td>${film.rating}</td>
                    <td><span class="badge badge-success">${film.status === true ? "Aktif" : "Pasif"}</span></td>
                    <td>
                        <div class="action-buttons">
                            <button class="btn btn-warning btn-sm" onclick="editFilm(${film.movieId})">
                                <i class="fas fa-edit"></i>
                            </button>
                            <button class="btn btn-danger btn-sm" onclick="deleteFilm('${film.movieId}','${film.title}')">
                                <i class="fas fa-trash"></i>
                            </button>
                        </div>
                    </td>
                </tr>`;
    $('#filmsTableBody').html(row);
}
document.getElementById('filmModal').addEventListener('click', function (e) {
    if (e.target === this) {
        closeModal();
    }
});

document.getElementById('deleteModal').addEventListener('click', function (e) {
    if (e.target === this) {
        closeDeleteModal();
    }
});
document.addEventListener('DOMContentLoaded', async function () {
    await getFilms();
})
document.getElementById('filmRating').addEventListener('input', function () {
    this.value = this.value
        .replace(/,/g, '.')           // Virgül → Nokta
        .replace(/[^0-9.]/g, '')      // Rakam + nokta dışını sil
        .replace(/(\..*)\./g, '$1');  // Tek nokta olsun
});

