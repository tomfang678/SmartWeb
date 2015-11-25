var validator = $("#save").kendoValidator().data("kendoValidator"), status = $(".status");
$(document).ready(function () {
    $("#save").click(function () {
        if (validator.validate()) {
            var jid = $("#staffid").val() == "" ? "0" : $("#staffid").val();
            var obj = [];
            obj = {
                id: jid,
                name: $("#name").val(),
                sex: $("#sex").val(),
                imgurl: $("#imgpath").val(),
                summary: $("#descripteditor").html(),
                remark: $("#contenteditor").html(),
                link: $("#link").val(),
                address: $("#address").val(),
                phone: $("#phone").val(),
                education: $("#education").val(),
                professional: $("#professional").val(),
                position: $("#position").val(),
                addtime: $("#addtime").val(),
                // updatetime: $("#updatetime").val(),
                state: $("#state").val(),
                isaccess: $("#isaccess").val(),
                homeshow: $("#homeshow").prop("checked"),
                conversiontime: $("#conversiontime").val(),
                entrytime: $("#entrytime").val(),
                idcard: $("#idcard").val(),
                department: $("#department").val(),
                doctorgroup: $("#doctorgroup").prop("checked"),
                managergroup: $("#managergroup").prop("checked"),
                orderno: $("#orderno").val(),
            };
            var str = JSON.stringify(obj);
            var ulr;
            if (jid == "0") {
                ulr = "/Admin/Staff/AddStaff";
            } else {
                ulr = "/Admin/staff/Update";
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
                        $.Zebra_Dialog('<strong>Sorry！</strong>,  执行失败', {
                            'type': 'error ',
                            'title': '异常提示'
                        });
                    }
                },
                error: function (mesg) {
                    $.Zebra_Dialog(mesg.responseText, {
                        'type': 'error ',
                        'title': '出现异常'
                    });
                }
            });
        }
    })
});