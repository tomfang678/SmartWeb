var PageSize, TotalPage, TotalCount;
$.getJSON("/Recruitment/Get", { PageIndex: "1", PageSize: "10" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    $("#joblist li").remove();
    var html = "";
    $.each(Data, function (index, value) {
        html += "<li id='list'><table class='imagetable'><tr><th style='width:75%;' ><a id='title' href='/Job/Detail?id=" + value.id + "' title='" + value.title + "' target='_blank'>" + value.position + "</a></th><th><span>发布日期：" + value.addtime + "</span></th></tr><tr><td colspan='2'><span>" + value.ShortDescript + "</span><br/><a style='color:#0026ff' href='/Job/Detail?id=" + value.id + "' title='查看详细' target='_self'>查看详细</a>&nbsp;&nbsp;&nbsp;&nbsp;<a style='color:red' href='/Resume' title='投简历' target='_self'>申请该职位</a></td></tr></table> </li>"
    });
    $("#joblist").append(html);
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Recruitment/Get", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}
