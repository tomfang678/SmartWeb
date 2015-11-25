var PageSize, TotalPage, TotalCount;
$.getJSON("/Home/GetByPage", { PageIndex: "1", PageSize: "15" }, function (data, state) {
    createList(data);
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
                desc = value.remark;
            }
            html += " <p><span class='image left'><a href='#'><img src='" + value.imgurl + "' alt='' style='width:170px;height:135px;' /></a></span><h4>" + value.name + "</h4>" + desc + "</p>";
        });
        $("#team").append(html);
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



