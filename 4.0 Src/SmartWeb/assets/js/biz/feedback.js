$("#save").click(function () {
    function check() {
        if ($("#checkcode").val() == "") {
            alert("请输入验证码");
            return false;
        }
        return true;
    }
    if (check()) {
        var obj = [];
        obj = {
            id: "0",
            name: $("#name").val(),
            tel: $("#tel").val(),
            email: $("#email").val(),
            contact: $("#subject").val(),
            info: $("#message").val()
        };
        var str = JSON.stringify(obj);
        $.ajax({
            type: "POST",
            url: "/Home/SendMessage?code=" + $("#checkcode").val(),
            datatype: "json",
            data: { models: str },
            success: function (data) {
                switch (data) {
                    case "0":
                        alert("验证码不正确");
                        break;
                    case "1":
                        alert("您已经添加过留言。");
                        location.href = "/generic.html";
                        break;
                    case "true":
                        alert("恭喜！您已经留言成功，我们会尽快处理，感谢您的支持！");
                        location.href = "/generic.html";
                        break;
                    case "false":
                        alert("Sorry！执行失败");
                        break;
                }
            },
            error: function (mesg) {
                alert(mesg);
            }
        });
    }
});