var validator = $("#addstudentshare").kendoValidator().data("kendoValidator"), status = $(".status");
$(document).ready(function () {
    $("#save").click(function () {
        if (validator.validate()) {
            var jid = $("#shareid").val() == "" ? "0" : $("#shareid").val();
            var obj = [];
            obj = {
                id: jid,
                name: $("#name").val(),
                title: $("#title").val(),
                company: $("#company").val(),
                studyclass: $("#studyclass").val(),
                newstime: $("#newstime").val(),
                //imgurl: $("#imgurl").val(),
                vediourl: $("#vediourl").val(),
                orderno: $("#orderno").val(),
                valid: $("#valid").prop("checked"),
                says: $("#says").html()
            };
            var str = JSON.stringify(obj);
            var ulr, msg;
            if (jid != "0") {
                ulr = "/Admin/StudentShare/Update";
            } else {
                ulr = "/Admin/StudentShare/AddStudentShare";
            }
            $.ajax({
                type: "POST",
                url: ulr,
                datatype: "json",
                data: { models: str },
                success: function (data, statu) {
                    if (statu == "success") {
                        var result = $.Zebra_Dialog('<strong>恭喜！</strong> 操作成功', {
                            'type': 'information ',
                            'title': '提示',
                            'buttons': [
                        { caption: 'Ok', callback: function () { location.reload(); } },
                            ]
                        });
                    } else {
                        $.Zebra_Dialog('<strong>Sorry！</strong>添加失败', {
                            'type': 'error ',
                            'title': '异常提示'
                        });
                    }
                },
                error: function (mesg) {
                    $.Zebra_Dialog('<strong>Sorry！</strong>操作失败'+mesg, {
                        'type': 'error ',
                        'title': '异常提示'
                    });
                }
            });
        }
    })
});
