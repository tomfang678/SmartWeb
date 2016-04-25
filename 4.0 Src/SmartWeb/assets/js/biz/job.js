var PageSize, TotalPage, TotalCount;
$.getJSON("/Recruitment/GetJobList", { PageIndex: "1", PageSize: "5" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
   createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    if (Data!=undefined) {
    $("#joblist").empty();
    $.each(Data, function (index, value) {
        $("#joblist").append("<div><h3><a href='recruitment_detail.html?id=" + value.id + "' alert='' traget='blank'>" + value.position + "—" + value.place + "</a></h3><p>" + value.shortdescript + " <a href='recruitment_detail.html?id=" + value.id + "' alert='查看详细信息' traget='blank'>更多...</a> </p><header><p><a class='button special' href='recruitment_hr.html'>应聘该职位</a></p> </header> </div><hr />");
    });
}
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Recruitment/GetJobList", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}
