$(document).ready(function () {
    $(".modal").dialog({
        position: {
            my: "center",
            at: "center",
            of: window
        },
        autoOpen: false,
        resizable: true,
        width: '80%',
    });

    let pagerOptions = {
        // target the pager markup - see the HTML block below
        container: $(".pager"),
        // output string - default is '{page}/{totalPages}';
        // possible variables: {size}, {page}, {totalPages}, {filteredPages}, {startRow}, {endRow}, {filteredRows} and {totalRows}
        // also {page:input} & {startRow:input} will add a modifiable input in place of the value
        output: '{startRow} - {endRow} / {filteredRows} ({totalRows})',
        // if true, the table will remain the same height no matter how many records are displayed. The space is made up by an empty
        // table row set to a height to compensate; default is false
        fixedHeight: false,
        // remove rows from the table to speed up the sort of large tables.
        // setting this to false, only hides the non-visible rows; needed if you plan to add/remove rows with the pager enabled.
        removeRows: false,
        // go to page selector - select dropdown that sets the current page
        cssGoto: '.gotoPage'
    };

    if ($('.tablesorter').find("#data-edit").length) {

        $('.tablesorter').tablesorter({
            theme: 'blue',
            showProcessing: true,
            headerTemplate: '{content} {icon}',
            widgets: ['uitheme', 'zebra', 'resizable', 'filter', 'scroller'],
            widgetOptions: {
                scroller_height: 300,
                // scroll tbody to top after sorting
                scroller_upAfterSort: true,
                // pop table header into view while scrolling up the page
                scroller_jumpToHeader: true,
                // In tablesorter v2.19.0 the scroll bar width is auto-detected
                // add a value here to override the auto-detected setting
                scroller_barWidth: null,
            }
        }).tablesorterPager(pagerOptions);
    } else {
        $(".pagesize").attr('disabled', true);;
    }

    $(".datepicker").datepicker({
        value: new Date(2013, 10, 10),
        dateFormat: "dd-M-yy",
        showStatus: true,
        showWeeks: true,
        autoSize: true,
        gotoCurrent: true,
        highlightWeek: true,
        maxDate: new Date(Date.now())
    }).datepicker("setDate", new Date($(".datepicker").val() === "01-Jan-0001" ? Date.now : $(".datepicker").val()));

    if ($("select[data-rule-hasSelection]").length > 0) {
        $.validator.addMethod("hasSelection", function (value, element) {
            let message = $("#" + element.id).parents("div.form-group").find("label").text();
            $.validator.messages["hasSelection"] = `The ${message} field is required.`
            return value !== "-1";
        });
    }

    $(".autoplay").slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 2000,
    });

    if ($(location).attr('pathname') === "/") {
        $("body").addClass("Index");
    } else {
        $("body").removeClass("Index");
    }

    $(".DisplayContactDetails").on("click", function (e) {
        e.preventDefault
        $(".modal").dialog("close");
        $("div").find(`[data-Contact-details-table='${$(this).attr('data-id')}']`).dialog("open");
    });
    $(".DisplayAddressDetail").on("click", function (e) {
        e.preventDefault();
        $(".modal").dialog("close");
        $("div").find(`[data-address-details-table='${$(this).attr('data-id')}']`).dialog("open");
    });
    $("#Department").change(function () {
        $.getJSON("/Staff/GetJobList", {
            DepartmentId: parseInt($("#Department").val())
        }, function (data) {
            let row = "";
            $("#JobTitle").empty();
            $.each(data, function (index, item) {
                row += "<option value=" + item.value + ">" + item.text + "</option>";
            });
            $("#JobTitle").html(row);
        })
    })
});