$(document).ready(function () {
    //validate form
    var checkEmail = false;              //email
    $("#Email").blur(function () {
        var email = $(this).val();
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (email === "") {
            $(".email-message").text("Email không được để trống");
            checkEmail = false;
        } else if (!email.match(re)) {
            $(".email-message").text("Email không hợp lệ");
            checkEmail = false;
        }
        else {
            $.ajax({
                url: '/Account/CheckEmailExist',
                dataType: "json",
                type: "GET",
                contentType: 'application/json; charset=utf-8',
                data: {
                    email: email
                },
                success: function (data) {
                    if (data === "Exist") {
                        $(".email-message").text("Email đã tồn tại");
                        checkEmail = false;
                    } else {
                        $(".email-message").text("");
                        checkEmail = true;
                    }
                },
                error: function (xhr) {
                    console.log("error email");
                }
            });
        }
    });
    //end email

    //username
    var checkUser = false;
    $("#UserName").blur(function () {
        var username = $(this).val();
        if (username === "") {
            $('.user-message').text("Tài khoản không được để trống");
            checkUser = false;
        } else {
            $.ajax({
                url: '/Account/CheckUserExist',
                dataType: "json",
                type: "GET",
                contentType: 'application/json; charset=utf-8',
                data: {
                    username: username
                },
                success: function (data) {
                    if (data === "Exist") {
                        $(".user-message").text("Tài khoản đã tồn tại");
                        checkUser = false;
                    } else {
                        $(".user-message").text("");
                        checkUser = true;
                    }
                },
                error: function (xhr) {
                    console.log("error checkusername");
                }
            });
        }
    });
    //end user              
    //password
    var checkPass = false;
    $("#Password").blur(function () {
        var pass = $(this).val();
        if (pass === "" || pass.length < 8) {
            $('.pass-message').text("Mật khẩu phải có ít nhất 8 ký tự");
            checkPass = false;
        } else if (hasNumber(pass) && hasUppercase(pass)) {
            $('.pass-message').text("");
            checkPass = true;
        }
        else {
            $('.pass-message').text("Mật khẩu phải chứa ít nhất 1 ký tự là số và 1 ký tự là chữ in hoa");
            checkPass = false;
        }
    });

    var checkRepass = false;
    $("#ConfirmPassword").blur(function () {
        var password = $("#Password").val();
        var repass = $(this).val();
        if (repass !== password) {
            $('.repass-message').text("Mật khẩu không khớp");
            checkRepass = false;
        } else{
            $('.repass-message').text("");
            checkRepass = true;
        }
    });

    //end pass
    function hasNumber(myString) {
        return /\d/.test(myString);
    }

    function hasUppercase(myString) {
        return /[A-Z]+/.test(myString);
    }

    //submit form
    $(".form").submit(function (e) {
        var email = $("#Email").val();
        var username = $("#UserName").val();
        var pass = $("#Password").val();
        e.preventDefault();
        if (checkEmail === true && checkPass === true && checkUser === true) {
            console.log("ABC");
            $.ajax({
                url: '/Account/Register',
                dataType: "json",
                type: 'POST',
                data: {
                    email: email,
                    username: username,
                    password: pass
                },
                success: function (data) {
                    var url = $("#RedirectTo").val();
                    location.href = url;
                },
                error: function (xhr) {
                    console.log("errror---" + xhr.responseText);
                }
            });
        } else {
            //email false
            if (checkEmail === false) {
                var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                if (email === "") {
                    $(".email-message").text("Email không được để trống");
                    checkEmail = false;
                } else if (!email.match(re)) {
                    $(".email-message").text("Email không hợp lệ");
                    checkEmail = false;
                }
                else {
                    $.ajax({
                        url: '/Account/CheckEmailExist',
                        dataType: "json",
                        type: "GET",
                        contentType: 'application/json; charset=utf-8',
                        data: {
                            email: email
                        },
                        success: function (data) {
                            if (data === "Exist") {
                                $(".email-message").text("Email đã tồn tại");
                                checkEmail = false;
                            } else {
                                $(".email-message").text("");
                                checkEmail = true;
                            }
                        },
                        error: function (xhr) {
                            console.log("error email");
                        }
                    });
                }
            }
            //end email false
            //password false
            if (checkPass === false) {
                if (pass === "" || pass.length < 8) {
                    $('.pass-message').text("Mật khẩu phải có ít nhất 8 ký tự");
                    checkPass = false;
                } else if (hasNumber(pass) && hasUppercase(pass)) {
                    $('.pass-message').text("");
                    checkPass = true;
                }
                else {
                    $('.pass-message').text("Mật khẩu phải chứa ít nhất 1 ký tự là số và 1 ký tự là chữ in hoa");
                    checkPass = false;
                }
            }
            //end password false
            //username false
            if (checkUser === false) {
                if (username === "") {
                    $('.user-message').text("Tài khoản không được để trống");
                    checkUser = false;
                } else {
                    $.ajax({
                        url: '/Account/CheckUserExist',
                        dataType: "json",
                        type: "GET",
                        contentType: 'application/json; charset=utf-8',
                        data: {
                            username: username
                        },
                        success: function (data) {
                            if (data === "Exist") {
                                $(".user-message").text("Tài khoản đã tồn tại");
                                checkUser = false;
                            } else {
                                $(".user-message").text("");
                                checkUser = true;
                            }
                        },
                        error: function (xhr) {
                            console.log("error checkusername");
                        }
                    });
                }
            }
            //end username false
            //check repass false
            if (checkRepass === false) {
                var password = $("#Password").val();
                var repass = $("#ConfirmPassword").val();
                if (repass !== password) {
                    $('.repass-message').text("Mật khẩu không khớp");
                    checkRepass = false;
                } else {
                    $('.repass-message').text("");
                    checkRepass = true;
                }
            }
        }
    });
})