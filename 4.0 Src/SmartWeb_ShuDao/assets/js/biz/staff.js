var PageSize, TotalPage, TotalCount;
$.getJSON("/Home/GetStaffList", { PageIndex: "1", PageSize: "15" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    var html = "";
    if (Data || Data.data > 0) {
        $("#team").empty();
        $.each(Data, function (index, value) {
            var desc = "";
            if (value.remark != "") {
                desc = value.remark.substring(0, 230);
            }
            html += " <p><span class='image left'><a href='/Staff/StarDetail?staffid=" + value.id + "'><img src='" + value.imgurl + "' alt='' style='width:200px;height:190px;' /></a></span><h4>" + value.name + "</h4>" + desc + "</p>";
            $("#team").append(html);
        });
    }
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Home/GetStaffList", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}



