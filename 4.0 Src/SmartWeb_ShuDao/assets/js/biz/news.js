var PageSize, TotalPage, TotalCount;
$.getJSON("/News/GetNewsList", { PageIndex: "1", PageSize: "15" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    $("#news").empty();
    if (Data != undefined) {
        var html = "";
        $.each(Data, function (index, value) {
            html = "<tr><td><img src='../images/dt-1.png'/><a href='news_detail.html?id=" + value.id + "' target='_blank'>" + value.title + "</a></td><td><span>[" + date2str(parseDate(value.addtime), 'yyyy-MM-dd') + "]</span></td>";
            $("#news").append(html);
        });
    } else {
        $("#news").append("<tr><td clospan='2'>暂无数据</td></tr>");
    }
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/News/GetNewsList", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}


