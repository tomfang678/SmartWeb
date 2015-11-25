var PageSize, TotalPage, TotalCount;
$("#share li").remove();
$.getJSON("/TraineeShare/GetValidList", { PageIndex: "1", PageSize: "15" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    $("#share li").remove();
    var html = "";
    $.each(Data, function (index, value) {
        html += "<li> <a href='/TraineeShare/Detail?id=" + value.id + "' target='_blank'>" + value.title + "</a><span>[" + date2str(parseDate(value.addtime), 'yyyy-MM-dd') + "]</span></li>";
    });
    $("#share").append(html);
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/TraineeShare/GetValidList", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}
