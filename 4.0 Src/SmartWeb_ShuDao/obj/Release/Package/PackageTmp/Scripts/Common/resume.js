$(document).ready(function () {
    var size = $("#age").kendoComboBox();
    var sex = $("#sex").kendoComboBox();
    var postation = $("#postation").kendoComboBox();
    var degree = $("#degree").kendoComboBox();
    $("#workyears").kendoNumericTextBox();
    var validator = $("#resume").kendoValidator().data("kendoValidator"), status = $(".status");

    $("#save").click(function () {
        if (validator.validate()) {
            var obj = [];
            obj = {
                id: 0,
                username: $("#name").val(),
                sex: $("#sex").val(),
                age: $("#age").val(),
                phone: $("#tel").val(),
                email: $("#email").val(),
                education: $("#education").val() + $("#degree").val(),
                workyears: $("#workyears").val(),
                postation: $("#postation").val(),
                speciality: $("#speciality").val(),
                remark: $("#remark").val(),
                talentpool: 0,
                isread: false
            };
            var str = JSON.stringify(obj);
            $.ajax({
                type: "POST",
                url: "/Resume/Add",
                data: { models: str },
                dataType: "json",
                success: function (data) {
                    if (data == true) {
                        var t = $.Zebra_Dialog('<strong>恭喜！</strong>您的简历已经成功提交，如果符合要求我们会尽快和您联系，再次感谢您的支持！', {
                            'type': 'information ',
                            'title': '提示',
                            'buttons': [
                           { caption: 'Ok', callback: function () { location.reload(); } },
                            ]
                        });
                    } else {
                        $.Zebra_Dialog('<strong>Sorry！</strong>,  简历提交失败', {
                            'type': 'error ',
                            'title': '异常提示'
                        });
                    }
                },
                error: function (mesg) {
                    $.Zebra_Dialog('<strong>Sorry！</strong>,  简历提交失败' + mesg, {
                        'type': 'error ',
                        'title': '异常提示'
                    });
                }
            });
            status.text("恭喜！您的简历我们已经接收，如果符合要求我们会尽快和你取得联系。")
                .removeClass("invalid")
                .addClass("valid");
        } else {
            status.text("请填将表单填写完整")
                .removeClass("valid")
                .addClass("invalid");
        }
    });
});
