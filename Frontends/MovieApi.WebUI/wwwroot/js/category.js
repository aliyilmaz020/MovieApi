let modalMode = 'create';
let categoryId = null;
let row = '';

const colorPicker = document.getElementById('categoryColor');
const colorHex = document.getElementById('categoryColorHex');

colorPicker.addEventListener('input', (e) => {
    colorHex.value = e.target.value;
});

colorHex.addEventListener('input', (e) => {
    if (/^#[0-9A-F]{6}$/i.test(e.target.value)) {
        colorPicker.value = e.target.value;
    }
});

function openModal() {
    modalMode = 'create';
    editingCategoryId = null;
    document.getElementById('categoryModal').classList.add('show');
    document.getElementById('modalTitle').textContent = 'Yeni Kategori Ekle';
    document.getElementById('saveBtn').innerHTML = '<i class="fas fa-save"></i> Kaydet';
    clearForm();
}

function closeModal() {
    document.getElementById('categoryModal').classList.remove('show');
    categoryId = null;
    clearForm();
}

async function editCategory(id) {
    modalMode = 'edit';
    categoryId = id;
    document.getElementById('categoryModal').classList.add('show');
    document.getElementById('modalTitle').textContent = 'Kategori Düzenle';
    document.getElementById('saveBtn').innerHTML = '<i class="fas fa-edit"></i> Güncelle';
    const category = await getCategory(id);
    if (category) {
        document.getElementById('categoryName').value = category.categoryName;
        document.getElementById('categoryIcon').value = category.icon;
        document.getElementById('categoryColor').value = category.color;
        document.getElementById('categoryColorHex').value = category.color;
        document.getElementById('categoryStatus').value = category.status.toString();
    }
}

function deleteCategory(id, name) {
    categoryId = id;
    document.getElementById('deleteCategoryName').textContent = name;
    document.getElementById('deleteModal').classList.add('show');
}

function closeDeleteModal() {
    document.getElementById('deleteModal').classList.remove('show');
    categoryId = null;
}

async function confirmDelete() {
    if (categoryId) {
        await removeCategory(categoryId);
        row = '';
        await getCategories();
        closeDeleteModal();
    }
}

async function saveCategory() {
    if (modalMode === 'create') {
        const category = {
            categoryName: $('#categoryName').val(),
            icon: $('#categoryIcon').val(),
            color: $('#categoryColorHex').val(),
            status: $('#categoryStatus').find(':selected').val() == 'true' ? true : false
        };
        await createCategory(category)
    } else {
        const category = {
            categoryId: categoryId,
            categoryName: $('#categoryName').val(),
            icon: $('#categoryIcon').val(),
            color: $('#categoryColorHex').val(),
            status: $('#categoryStatus').find(':selected').val() == 'true' ? true : false
        };
        await updateCategory(category);
    }
    row = '';
    await getCategories();
    closeModal();
}

function filterCategories() {
    const searchTerm = document.getElementById('searchInput').value;
    const status = document.getElementById('statusFilter').value;

    console.log('Arama:', searchTerm, 'Durum:', status);
}

// Modal dışına tıklandığında kapat
document.getElementById('categoryModal').addEventListener('click', function (e) {
    if (e.target === this) {
        closeModal();
    }
});
document.addEventListener('DOMContentLoaded', async () => {
    await getCategories();
})
document.getElementById('deleteModal').addEventListener('click', function (e) {
    if (e.target === this) {
        closeDeleteModal();
    }
});

const fillCategoryData = (category) => {
    row += `<div class="category-card" style="border-color: ${category.color};">
            <div class="category-header">
                <div>
                    <div class="category-icon" style="background:  ${category.color};">
                        <i class="${category.icon}"></i>
                    </div>
                    <div class="category-name">${category.categoryName}</div>
                </div>
                <div class="category-actions">
                    <button class="btn btn-warning btn-sm" onclick="editCategory('${category.categoryId}')">
                        <i class="fas fa-edit"></i>
                    </button>
                    <button class="btn btn-danger btn-sm" onclick="deleteCategory('${category.categoryId}', '${category.categoryName}')">
                        <i class="fas fa-trash"></i>
                    </button>
                </div>
            </div>
            <div class="category-stats">
                <div class="category-stat">
                    <span class="stat-label">Film Sayısı</span>
                    <span class="stat-value">42</span>
                </div>
                <div class="category-stat">
                    <span class="stat-label">Görüntülenme</span>
                    <span class="stat-value">15.2K</span>
                </div>
            </div>
        </div>`
    $('#categoriesGrid').html(row)
}
const getCategories = async () => {
    const response = await fetch("/Admin/Category/GetCategories", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=utf-8'
        }
    });
    if (!response.ok) {
        toastr("Başarısız", `Bir hata oluştu: ${response.status}`, 'bg-danger');
    }
    const data = await response.json();
    const categories = JSON.parse(data);
    categories.forEach(category => {
        fillCategoryData(category)
    })
}
const getCategory = async (id) => {
    const response = await fetch(`/Admin/Category/GetCategory/${id}`, {
        method: "POST",
        headers: {
            'Content-Type': "application/json;charset=utf-8"
        }
    });
    if (!response.ok)
        toastr("Başarısız", `Bir hata oluştu: ${response.status}`, 'bg-danger');
    const data = JSON.parse(await response.json());
    return data;
}
const createCategory = async (category) => {
    const response = await fetch("/Admin/Category/CreateCategory", {
        method: "POST",
        headers: {
            'Content-Type': "application/json; charset=utf-8;"
        },
        body: JSON.stringify(category)
    });
    if (response.ok)
        toastr("Başarılı", "Kategori Ekleme İşlemi Başarılı");
    else
        toastr("Başarısız", `Bir hata oluştu: ${response.status}`, 'bg-danger');
}
const updateCategory = async (category) => {
    const response = await fetch("/Admin/Category/UpdateCategory", {
        method: "POST",
        headers: {
            'Content-Type': "application/json; charset=utf-8;"
        },
        body: JSON.stringify(category)
    });
    if (response.status)
        toastr("Başarılı", "Kategori Güncelleme İşlemi Başarılı");
    else
        toastr("Başarısız", `Bir hata oluştu: ${response.status}`, 'bg-danger');
}
const removeCategory = async (id) => {
    const response = await fetch(`/Admin/Category/RemoveCategory?id=${id}`, {
        method: "POST",
        headers: {
            'Content-Type': "application/json; charset=utf-8;"
        }
    });
    if (response.ok)
        toastr("Başarılı", "Kategori Silme İşlemi Başarılı");
    else
        toastr("Başarısız", `Bir hata oluştu: ${response.status}`, 'bg-danger');
}
function clearForm() {
    $('.modal-body').find('input, textarea').val('');
}
