// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

 function OnSignup (token) {
    var data = new FormData();
    data.append("SignupRequest.ReCatpchaToken", token);
    data.append("SignupRequest.Email", $("#txtEmail").val());
    data.append("SignupRequest.Password", $("#txtPassword").val());
    data.append("SignupRequest.ConfirmPassword", $("#txtConfirmPassword").val());
    data.append("SignupRequest.Name", $("#txtName").val());

    $.ajax({
        url: "https://localhost:7124?handler=Signup",
        type: 'POST',
        data: data,
        processData: false,
        contentType: false,
        global: false,
        success: function () {
            var stuff = "";
        },
        error: function () {
            var stuff = "";
        }
    });
}

$(function () {
    $(document).on('click', '#btnSignup', function (e) {
        e.preventDefault();
        grecaptcha.ready(function () {
            
            grecaptcha.execute('{site-key}', { action: 'signup' })
                .then(function (token) {
                    $('#hdnGoogleRecaptcha').val(token);
                    $('#lblValue').html(token);

                    $.post("https://localhost:7124?handler=Signup",
                        {
                            email: $("#txtEmail").val(),
                            password: $("#txtPassword").val(),
                            confirmPassword: $("#txtConfirmPassword").val(),
                            name: $("#txtName").val(),
                            recaptchaToken: hdnGoogleRecaptcha.val()
                        })
                        .done(function (result, status, xhr) {
                            $("#lblMessage").html(result)
                        })
                        .fail(function (xhr, status, error) {
                            $("#lblMessage").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
                        });
            });
        });
    });
});
