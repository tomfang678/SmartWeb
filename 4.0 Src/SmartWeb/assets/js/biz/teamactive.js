var PageSize, TotalPage, TotalCount;
var newstype = $("#newstype").val();
$("#news li").remove();
$.getJSON("/News/GetNewsList?newstype=" + newstype, { PageIndex: "1", PageSize: "15" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    $("#news li").remove();
    var html = "";
    $.each(Data, function (index, value) {
        html += "<li> <a href='/Staff/ActiveDetail?type=" + newstype + "&id=" + value.id + "' target='_blank'>" + value.title + "</a><span>[" + date2str(parseDate(value.addtime), 'yyyy-MM-dd') + "]</span></li>";
    });
    $("#news").append(html);
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/News/GetNewsList?newstype=" + newstype, { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}


