var validator = $("#appoint").kendoValidator().data("kendoValidator"), status = $(".status");
$("#save").click(function () {
    if (validator.validate()) {
        var obj = [];
        obj = {
            id: "0",
            name: $("#name").val(),
            tel: $("#tel").val(),
            email: $("#email").val(),
            contact: $("#address").val(),
            info: $("#remark").val()
        };
        var str = JSON.stringify(obj);
        $.ajax({
            type: "POST",
            url: "/Feedback/Add",
            datatype: "json",
            data: { models: str },
            success: function (data) {
                if (data == true) {
                    var t = $.Zebra_Dialog('<strong>恭喜！</strong>, 您已经留言成功，我们会尽快处理，感谢您的支持！', {
                        'type': 'information ',
                        'title': '提示'
                    });
                    location.href = "/Feedback/";
                } else {
                    $.Zebra_Dialog('<strong>Sorry！</strong>,  执行失败', {
                        'type': 'error ',
                        'title': '异常提示'
                    });
                }
            },
            error: function (mesg) {
                alert(mesg);
            }
        });
    }
});