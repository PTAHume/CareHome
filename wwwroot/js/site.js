$(document).ready(function () {
    $(".modal").dialog({
        autoOpen: false,
        resizable: true,
        width: '80%',
    });

    var $table = $('.tableSorter'),
        // define pager options
        pagerOptions = {
            // target the pager markup - see the HTML block below
            container: $(".pager"),
            // output string - default is '{page}/{totalPages}';
            // possible variables: {size}, {page}, {totalPages}, {filteredPages}, {startRow}, {endRow}, {filteredRows} and {totalRows}
            // also {page:input} & {startRow:input} will add a modifiable input in place of the value
            output: '{startRow} - {endRow} / {filteredRows} ({totalRows})',
            // if true, the table will remain the same height no matter how many records are displayed. The space is made up by an empty
            // table row set to a height to compensate; default is false
            fixedHeight: true,
            // remove rows from the table to speed up the sort of large tables.
            // setting this to false, only hides the non-visible rows; needed if you plan to add/remove rows with the pager enabled.
            removeRows: false,
            // go to page selector - select dropdown that sets the current page
            cssGoto: '.gotoPage'
        };

    $table
        .tablesorter({
            theme: 'blue',
            headerTemplate: '{content} {icon}', // new in v2.7. Needed to add the bootstrap icon!
            widthFixed: true,
            widgets: ['zebra', 'filter'],
        })

        // initialize the pager plugin
        // ****************************
        .tablesorterPager(pagerOptions);

    $(".datepicker").datepicker({
        value: new Date(2013, 10, 10),
        dateFormat: "dd-M-yy",
        showStatus: true,
        showWeeks: true,
        autoSize: true,
        gotoCurrent: true,
        highlightWeek: true,
        maxDate: new Date(Date.now())
    }).datepicker("setDate", new Date($(".datepicker").val() === '01-Jan-0001' ? Date.now : $(".datepicker").val()));



    $(".DisplayContactDetails").on("click", function (e) {
        e.preventDefault();
        // $(".modal").dialog("close");
        $("div").find(`[data-Contact-details-table='${$(this).attr('data-id')}']`).dialog("open");
    });
    $(".DisplayAddressDetail").on("click", function (e) {
        e.preventDefault();
        // $(".modal").dialog("close");
        $("div").find(`[data-address-details-table='${$(this).attr('data-id')}']`).dialog("open");
    });
    $("#Department").change(function () {
        $.getJSON("/Staff/GetJobList", { DepartmentId: parseInt($("#Department").val()) }, function (data) {
            let row = "";
            $("#JobTitle").empty();
            $.each(data, function (index, item) {
                row += "<option value=" + item.value + ">" + item.text + "</option>";
            });
            $("#JobTitle").html(row);
        })
    })
});