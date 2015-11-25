 var validator = $("#addStar").kendoValidator().data("kendoValidator"), status = $(".status");
$(document).ready(function () {
    $("#save").click(function () {
        if (validator.validate()) {
            var jid = $("#starid").val() == "" ? "0" : $("#starid").val();
            var obj = [];
            obj = {
                id: jid,
                stafftype: $("#staffType").val(),
                title: $("#title").val(),
                //staffid: $("#count").val(),
                selecttime: $("#selecttime").val(),
                orderno: $("#orderno").val(),
                isvalide: $("#isvalide").prop("checked"),
                imgurl: $("#imgpath").val(),
                shortdesc: $("#shortdesc").html(),
                story: $("#story").html(),
            };
            var str = JSON.stringify(obj);
            var ulr, msg;
            if (jid != "0") {
                ulr = "/Admin/StaffStar/Update";
            } else {
                ulr = "/Admin/StaffStar/Release";
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
