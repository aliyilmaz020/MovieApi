$('#formRegister').on('submit', function (e) {
    e.preventDefault();
    let formData = {
        name: $('#name-2').val(),
        surname: $('#surname-2').val(),
        userName: $('#username-2').val(),
        email: $('#email-2').val(),
        password: $('#password-2').val()
    }
    $.ajax("/User/Register", {
        method: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(formData),
        success: function (response) {
            alert("Registration successful!");
        },
        error: function (error) {
            alert("An error occurred: " + error.responseText);
        }
    })
})
$('#formLogin').on('submit', function (e) {
    e.preventDefault();

    let formData = {
        userNameOrEmail: $('#usernameOrEmail').val(),
        password: $('#password').val()
    }
    $.ajax("/User/Login", {
        method: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(formData),
        success: function (response) {
            debugger
            setTimeout(() => {
                window.location.href = "/Movie/MovieList";
            }, 5000);
        },
        error: function (error) {
            alert("An error occurred: " + error.responseText);
        }
    })
})
$('#password-2,#repassword-2').on('blur', function () {
    const pass = $('#password-2').val();
    const repass = $('#repassword-2').val();
    const passwordMessage = $('#passwordMessage');
    if (!pass || !repass) return;
    if (pass !== repass) {
        passwordMessage.text('Şifreler eşleşmiyor').css('color', 'red');
    }
    else {
        passwordMessage.text('');
    }
})
$('#username-2,#email-2').on('blur', function () {
    $.ajax("/User/CheckEmailAndUsername", {
        method: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            email: $('#email-2').val(),
            username: $('#username-2').val()
        }),
        success: function (response) {
            debugger
            const obj = JSON.parse(response)
            if (obj.status !== 400) {
                if (obj.isTakenEmail === true) {
                    $('#emailMessage').text('Bu email zaten kullanılıyor').css('color', 'red');
                } else {
                    $('#emailMessage').text('');
                }
                if (obj.isTakenUsername === true) {
                    $('#usernameMessage').text('Bu kullanıcı adı zaten kullanılıyor').css('color', 'red');
                } else {
                    $('#usernameMessage').text('');
                }
            }

        },
    })
})
