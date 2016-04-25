$(document).ready(function () {
    function check() {
        var error = "";
        if ($("#name").val() == "") error = "用户名，";
        if ($("#address").val() == "") error += "籍贯，";
        if ($("#education").val() == "") error += "学历，";
        if ($("#postation").val() == "") error += "职位，";
        if ($("#email").val() == "") error += "邮箱，";
        if ($("#phone").val() == "") error += "手机，";
        if ($("#remark").val() == "") error += "简历，";
        if (error != "") {
            alert(error + "   不能为空");
            $("#checkmsg").append(error + "  不能为空");
            return false;
        }
        if (!(/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/.test($("#email").val()))) {
            alert("请填写的正确的邮箱地址");
            return false;
        }
        if (!(/^1[3|5][0-9]\d{4,8}$/.test($("#phone").val()))) {
            alert("不是完整的11位手机号或者正确的手机号前七位");
            return false;
        }
        if (!(Math.floor($("#age").val()) == $("#age").val())) {
            alert("年龄不是整数");
            return false;
        }
        if (!(Math.floor($("#workyears").val()) == $("#workyears").val())) {
            alert("工作年限不是整数");
            return false;
        }
        return true;
    }

    $("#save").click(function () {
        if (check()) {
            var myDate = new Date();

            var sex = $("#priority-low").checked ? 0 : 1;
            var obj = [];
            obj = {
                id: 0,
                username: $("#name").val(),
                sex: sex,
                age: $("#age").val(),
                education: $("#school").val() + ";" + $("#education").find("option:selected").text()+ ";" + $("#address").val(),
                phone: $("#phone").val(),
                qq: $("#qq").val(),
                email: $("#email").val(),
                files: "",
                workyears: $("#workyears").val(),
                postation: $("#postation").find("option:selected").text(),
                speciality: $("#speciality").val(),
                remark: $("#remark").val(),
                talentpool: 0,
                isread: false
            };
            var str = JSON.stringify(obj);
            $.ajax({
                type: "POST",
                url: "/Recruitment/SendResume?code=" + $("#checkcode").val(),
                //contentType: "application/json",
                data: { model: str },
                dataType: "json",
                success: function (data) {
                    switch (data) {
                        case "0":
                            alert("验证码不正确");
                            break;
                        case "1":
                            alert("您的简历已经存在。");
                            location.href = "/recruitment_hr.html";
                            break;
                        case true:
                            alert("恭喜！您的简历已经成功提交，如果符合要求我们会尽快和您联系，再次感谢您的支持！");
                            location.href = "/recruitment_hr.html";
                            break;
                        case false:
                            alert("Sorry！简历提交失败!");
                            break;
                    }
                },
                error: function (mesg) {
                    alert("简历提交失败" + mesg);
                }
            });
        }
    });
});
