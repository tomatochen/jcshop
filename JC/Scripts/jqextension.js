﻿jQuery.get2 = function (a, c, b) { jQuery.ajax({ url: a, type: "GET", data: c, contentType: "application/json; charset=utf-8", dataType: "json", cache: false, async: false, success: function (d) { if (jQuery.isFunction(b)) { b(d) } }, error: function (e, d) { if (d == "error") { alert("请求异常") } else { alert(d) } }, beforeSend: function (d) { if (!c) { d.setRequestHeader("Content-Type", "application/json; charset=utf-8") } } }) }; jQuery.post2 = function (a, c, b) { jQuery.ajax({ url: a, type: "POST", data: c, contentType: "application/json; charset=utf-8", dataType: "json", cache: false, async: false, success: function (d) { if (jQuery.isFunction(b)) { b(json) } }, error: function (e, d) { if (d == "error") { alert("请求异常") } else { alert(d) } }, beforeSend: function (d) { if (!c) { d.setRequestHeader("Content-Type", "application/json; charset=utf-8") } } }) }; jQuery.confirm = function (b, a) { bootbox.confirm({ size: "small", message: b, buttons: { cancel: { label: "取消", className: "btn-default btn-sm", }, confirm: { label: "确定", className: "btn-primary btn-sm", } }, callback: function (c) { if (c && jQuery.isFunction(a)) { a() } } }) }; jQuery.alert = function (b, a) { bootbox.alert({ size: "small", message: b, buttons: { ok: { label: "确定", className: "btn-primary btn-sm", } }, callback: function () { if (a && jQuery.isFunction(a)) { a() } } }) }; function styleCheckbox(a) { } function updateActionIcons(a) { } function updatePagerIcons(b) { var a = { "ui-icon-seek-first": "ace-icon fa fa-angle-double-left bigger-140", "ui-icon-seek-prev": "ace-icon fa fa-angle-left bigger-140", "ui-icon-seek-next": "ace-icon fa fa-angle-right bigger-140", "ui-icon-seek-end": "ace-icon fa fa-angle-double-right bigger-140" }; $(".ui-pg-table:not(.navtable) > tbody > tr > .ui-pg-button > .ui-icon").each(function () { var d = $(this); var c = $.trim(d.attr("class").replace("ui-icon", "")); if (c in a) { d.attr("class", "ui-icon " + a[c]) } }) } function enableTooltips(a) { $(".navtable .ui-pg-button").tooltip({ container: "body" }); $(a).find(".ui-pg-div").tooltip({ container: "body" }) } function forjqgrid(a) { styleCheckbox(a); updateActionIcons(a); updatePagerIcons(a); enableTooltips(a) };