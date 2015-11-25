$(document).ready(function () {
    $("#login").click(function () {
        var name = $("#login-name").val();
        var pwd = $("#login-pass").val();
        var validcode = $("#login-valicode").val();
        if (validcode == "") {
            alert("验证码不能为空！");
            return;
        }
        var isrecord = $("#recode").is(':checked');
        if (name == "" || pwd == "" || name == "请输入用户名" || pwd == "请输入密码") {
            alert("用户名和密码不能为空！");
            location.href = "/Admin/Account/Login";
        } else {
            $.post("/Admin/Account/Login", { name: name, pwd: pwd, validcode: $("#login-valicode").val(), record: isrecord }, function (data, status) {
                if (data.Success) {
                    location.href = "/Admin/Home";
                }
                else {
                    alert(data.Message);
                }
            });
        }
    });
});
