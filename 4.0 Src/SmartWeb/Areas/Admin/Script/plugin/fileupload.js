$(document).ready(function () {
    var filepath = "";
    var filesize;
    var filename;
    var filetype;
    var downloadpath;
    $("#files").kendoUpload({
        async: {
            saveUrl: "/Admin/FileUpload/FileSave",
            removeUrl: "/Admin/FileUpload/FileRemove",
            autoUpload: true
        },
        upload: onUpload,
        success: onSuccess,
        error: onError
    });
    function onSuccess(e) {
        if (e.operation == "upload") {
            filesize = e.files[0].size;
            filename = e.files[0].name;
            filetype = e.files[0].extension;
            var size = filesize / 1024;
            downloadpath = JSON.parse(e.XMLHttpRequest.response);
            filepath += JSON.parse(e.XMLHttpRequest.response) + "|";
            $("#img").attr("src", downloadpath[0]);
            $("#imgpath").attr("value", downloadpath[0]);
        }
    }
    function onError(e) {
        // Array with information about the uploaded files
        var files = e.files;
        if (e.operation == "upload") {
            $.Zebra_Dialog("Failed to upload " + files.length + " files", {
                'type': 'error ',
                'title': '警告'
            });
        }
    }
    function onUpload(e) {
        var files = e.files;
        $.each(files, function () {
            if (this.extension.toLowerCase() == ".exe" || this.extension.toLowerCase() == ".msi" || this.extension.toLowerCase() == ".dll" || this.extension.toLowerCase() == ".bat") {
                $.Zebra_Dialog("该格式非法，禁止上传", {
                    'type': 'error ',
                    'title': '警告'
                });
                e.preventDefault();
            }
        })
    };
});