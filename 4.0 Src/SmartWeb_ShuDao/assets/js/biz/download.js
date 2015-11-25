var PageSize, TotalPage, TotalCount;
$.getJSON("/Download/GetDownloadList", { PageIndex: "1", PageSize: "10" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalCount / data.PageSize;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    $("#downlist").empty();
    if (Data.data>0) {
        $.each(Data, function (index, value) {
            $("#downlist").append("<tr><td><a href='" + value.downloadurl + "'>" + value.title + "</a></td><td><p>" + value.content + "</p></td><td>" + value.filetype + "<td> " + date2str(parseDate(value.addtime), 'yyyy-MM-dd') + "</td></tr>");
        });
    } else {
        $("#downlist").append("<tr><td colspan='4'>暂无数据显示<td></tr>");
    }
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Download/GetDownloadList", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}

