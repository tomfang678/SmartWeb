var PageSize, TotalPage, TotalCount;
$.get("/Staff/GetByPage", { PageIndex: "1", PageSize: "15" }, function (data, state) {
    createList(data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    $("#staffstar dl").remove();
    var html = "";
    $.each(Data, function (index, value) {
        alert(value.id);
        html += "<dl><dt> <a href='/Staff/StaffStarDetail?id=" + value.id + "'><img src=" + value.imgurl + " alt='" + value.name + "' title='" + value.name + "' width='130' height='130' /></a></dt><dd> <b>" + value.name + "</b><font face=Verdana><font face=Verdana>" + value.summary + "</font></font> </dd> </dl><div class='line-gray'></div>";
    });
    $("#staffstar").append(html);
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Staff/GetStaffStarList", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}




