
/*******清除表单数据*********/
function ClearForm(obj) {
    obj.find(':input').not(':button, :submit, :reset').val('').removeAttr('checked').removeAttr('selected');
}

/*******关闭模态框*********/
function CloseModal(id) {
    $('#' + id).modal('hide');
    ClearForm($("#modalForm-content"));
}

/*******查询*********/
function SearchRecord(actionUrl, oTable) {
    oTable.fnReloadAjax(actionUrl);
}


/*******删除全部操作*********/
function DeleteAllRecord(actionUrl, oTable) {
    bootbox.dialog("你确认要删除所有记录？", [{
        "label": "删除",
        "class": "btn-danger",
        "callback": function () {
            $.ajax({
                type: "POST",
                url: actionUrl,
                beforeSend: function () {
                    //
                },
                success: function (result) {
                    bootbox.alert(result.Message);
                    if (result.ResultType == 0) {
                        ReloadDataTable(oTable);
                    }
                },
                error: function () {
                    //
                },
                complete: function () {
                    //
                }
            });
        }
    }, {
        "label": "取消",
        "class": "btn-default"
    }]);
}



/*******初始化表格
dataTableObj:初始化对象
fnDrawCallback:绘制完表格之后的回调函数
aoColumns:列信息
actionUrl:请求地址
ServerData:请求参数设置，传null为默认设置
fnRowCallback:单行回调方法
objTable:初始化完成后返回对象
flag:是否需要绑定行双击事件,true为绑定
*********/
function InitDatatables(dataTableObj, fnDrawCallback, aoColumns, actionUrl, ServerData, fnRowCallback, objTable, flag) {
    objTable = dataTableObj.dataTable({
        "fnDrawCallback": fnDrawCallback,//绘制完表格之后的回调函数
        "aoColumns": aoColumns,
        "bServerSide": true,//分页，取数据等等的都放到服务端去
        "bProcessing": true,//载入数据的时候是否显示“载入中”
        "aLengthMenu": [30, 50, 100],
        "bLengthChange": true, //改变每页显示数据数量
        //"bFilter": false, //过滤功能
        "iDisplayStart": 0,
        "iDisplayLength": 30,//首次加载的数据条数
        "bStorable": true,//排序操作在服务端进行，所以可以关了。
        "sAjaxSource": actionUrl,
        "fnServerParams": function (aoData, bStorable) {
        },
        /*如果加上下面这段内容，则使用post方式传递数据*/
        "fnServerData": ServerData == null ? DefaultServerData : ServerData,
        "oLanguage": {
            "sSearch": "搜索",
            "sLengthMenu": "每页显示 _MENU_ 条记录",
            "sZeroRecords": "抱歉， 没有找到",
            "sInfo": "从 _START_ 到 _END_ 共 _TOTAL_ 条数据",
            "sInfoEmpty": "",
            "sInfoFiltered": "(从 _MAX_ 条数据中检索)",
            "oPaginate": {
                "sFirst": "首页",
                "sPrevious": "前一页",
                "sNext": "后一页",
                "sLast": "尾页"
            },
            "sZeroRecords": "没有检索到数据",
            "sProcessing": "<img src='/Content/admin/images/loading-11.gif' />"
        },
        "fnRowCallback": fnRowCallback /* 用来改写指定行的样式 */
    });
    if (flag) {
        $(dataTableObj).find('tbody').on('dblclick', 'tr', function (event) {
            try {
                //$(dataTableObj).find("tbody tr input[type='checkbox']").each(function () {
                //    this.checked = false;
                //})
                //$(this).find("td:first input[type='checkbox']").each(function () {
                //    this.checked = true;
                //})
                ShowUpdateModel($(this).attr("data-id"))
            }
            catch (e) { }
        });
    }
}
/*******默认的列表post请求*********/
var DefaultServerData = function (sSource, aoData, fnCallback, bStorable) {
    var paramList = {
        "sEcho": 0,
        "iDisplayLength": 0,
        "iDisplayStart": 0,
        "isDesc": bStorable.aaSorting[0][1] == "desc" ? true : false
    };
    if (bStorable.aaSorting[0][0] == 0) {
        paramList.isDesc = true;
    }
    for (var i = 0; i < aoData.length; i++) {
        if (aoData[i].name == "iDisplayStart") {
            paramList.iDisplayStart = aoData[i].value;
        } else if (aoData[i].name == "iDisplayLength") {
            paramList.iDisplayLength = aoData[i].value;
        } else if (aoData[i].name == "sEcho") {
            paramList.sEcho = aoData[i].value;
        }
    }
    $.ajax({
        "dataType": 'json',
        "type": "POST",
        "url": sSource,
        "data": paramList,
        "success": function (resp) {
            fnCallback(resp); //服务器端返回的对象的returnObject部分是要求的格式
        },
        "error": function (resp) {
            alert(resp.responseText)
        }
    });
}
/*******将表格上方的左右对换（将下拉框的位置移到右边去）*********/
function ChangeLeftToRight() {
    $("#list_table_length").parents().first().removeClass("col-sm-6").addClass("col-sm-3");
    $("#list_table_length").parents().first().css("float", "right");
    $("#list_table_filter").parents().first().removeClass("col-sm-6").addClass("col-sm-8");
    $("#list_table_filter").parents().first().css("float", "left");
    $("#list_table_length").css("float", "right");
    $("#list_table_filter").html($("#hidden_filter").html());
    $("#hidden_filter").remove();
}
/*******返回checkbox的Html代码*********/
function GetCheckBoxHtml(id) {
    return "<label><input type=\"checkbox\" class=\"ace\" value=\"" + id + "\"><span class=\"lbl\"></span></label>"
}
/*******返回编辑按钮的Html代码*********/
function GetEditHtml(id) {
    return "<a class=\"green UpdateModelLookRole\" href=\"javascript:ShowUpdateModel('" + id + "')\" title=\"编辑\"><i class=\"icon-pencil bigger-130\"></i></a>";
}
/*******返回删除按钮的Html代码*********/
function GetDeleteHtml(id) {
    return "<a class=\"red DeleteModelRole\" href=\"javascript:DeleteModel('" + id + "')\" title=\"彻底删除\"><i class=\"icon-trash bigger-130\"></i></a>";
}
/*******弹出表单*********/
function ShowModal(actionUrl, param) {
    $.ajax({
        type: "Get",
        url: actionUrl,
        data: param,
        beforeSend: function () {
            $("#list_table_processing").css("visibility", "visible");
        },
        success: function (result) {
            if (result.split(',')[0] == "error") {
                bootbox.alert({
                    buttons: {
                        ok: {
                            label: '我知道了',
                            className: 'btn btn-primary'
                        }
                    }, callback: function () {
                    },
                    message: result.split(',')[1]
                });
                return false;
            } else {
                $("#ShowPublicModel").empty();
                $("#ShowPublicModel").html(result);
                $('#ShowPublicModel').modal('show');
            }
            //RegisterForm();
        },
        error: function () {
            //
        },
        complete: function () {
            $("#list_table_processing").css("visibility", "hidden");
        }
    });
}
/*******表单提交之前操作*********/
function OnBeginFunction() {
    $("#list_table_processing").css("visibility", "visible");
    //disabled
    $(".SubmitButton button").addClass("disabled");
}
/*******表单提交后操作*********/
function OnCompleteFunction() {
    $("#list_table_processing").css("visibility", "hidden");
    $(".SubmitButton button").removeClass("disabled");
}
/*******表单提交成功操作*********/
function OnSuccessFunction(data) {
    if (data.state == "success") {
        ShowSuccessBoxAlert(data.message);
        return true;
    } else {
        BootBoxAlert(data.message);
    }
    //return false;
}
/*******表单提交出错操作*********/
function OnFailureFunction(data) {
    
}
/*******根据请求结果进行操作*********/
function AjaxResult(result) {
    if (result.state == "error") {
        BootBoxAlert(result.message);
    } else {
        ShowSuccessBoxAlert(result.message);
    }
}
/*******删除操作*********/
function DeleteRecord(actionUrl, param) {
    bootbox.confirm({
        buttons: {
            confirm: {
                label: '确定',
                className: 'btn-primary'
            },
            cancel: {
                label: '取消',
                className: 'btn-default'
            }
        },
        message: "你确认要删除这条记录",
        callback: function (result) {
            if (result) {
                $.ajax({
                    type: "POST",
                    url: actionUrl,
                    data: param,
                    beforeSend: function () {
                        ShowLoadingImage();
                    },
                    success: function (result) {
                        if (result.state == "success") {
                            ShowSuccessBoxAlert(result.message);
                        } else {
                            BootBoxAlert(result.message);
                        }
                    },
                    error: function () {
                        //
                    },
                    complete: function () {
                        HideLoadingImage();
                    }
                });
            }
        }
    });
}
/*******修改是否显示状态*********/
/***
*data:请求数据
*url:请求地址
*message:提示信息
**/
function UpdateState(data, url,message) {
    bootbox.confirm({
        buttons: {
            confirm: {
                label: '确定',
                className: 'btn-primary'
            },
            cancel: {
                label: '取消',
                className: 'btn-default'
            }
        },
        message: message,
        callback: function (result) {
            if (result) {
                $.ajax({
                    type: "post",
                    url: url,
                    data: data,
                    beforeSend: function () {
                        ShowLoadingImage();
                    },
                    success: function (result) {
                        AjaxResult(result);
                    },
                    error: function () {
                        //
                    },
                    complete: function () {
                        HideLoadingImage();
                    }
                });
            }
        }
    });
}
/*******弹出错误信息，不做任何处理*********/
function BootBoxAlert(message) {
    bootbox.alert({
        buttons: {
            ok: {
                label: '我知道了',
                className: 'btn btn-warning'
            }
        }, callback: function () {

        },
        message: message
    });
}
/*******t弹出成功信息，并关闭模态框和重新绘制表格*********/
function ShowSuccessBoxAlert(message) {
    bootbox.alert({
        buttons: {
            ok: {
                label: '我知道了',
                className: 'btn btn-primary'
            }
        }, callback: function () {
            $('#ShowPublicModel').modal('hide');
            try{
                $("#list_table").dataTable().fnDraw();//点搜索重新绘制table。
            } catch (e) {
                location.reload();
            }
        },
        message: message
    });
}
/*******弹出确认框*********/
function ShowConfirm(message, callBackFunction) {
    bootbox.confirm({
        buttons: {
            confirm: {
                label: '确定',
                className: 'btn-primary'
            },
            cancel: {
                label: '取消',
                className: 'btn-default'
            }
        },
        message: message,
        callback: callBackFunction
    });
}
/*******显示加载中图片*********/
function ShowLoadingImage() {
    $("#list_table_processing").css("visibility", "visible");
}
/*******隐藏加载中图片*********/
function HideLoadingImage() {
    $("#list_table_processing").css("visibility", "hidden");
}
/*******转换时间格式*********/
function GetDateYMR(dateFirst) {
    if (dateFirst) {
        return new Date(Number(dateFirst.replace(/\D/g, ''))).getFullYear() + '-' + (new Date(Number(dateFirst.replace(/\D/g, ''))).getMonth() + 1 < 10 ? '0' + (new Date(Number(dateFirst.replace(/\D/g, ''))).getMonth() + 1) : new Date(Number(dateFirst.replace(/\D/g, ''))).getMonth() + 1) + '-' + (new Date(Number(dateFirst.replace(/\D/g, ''))).getDate() < 10 ? '0' + (new Date(Number(dateFirst.replace(/\D/g, ''))).getDate() + 1) : new Date(Number(dateFirst.replace(/\D/g, ''))).getDate() + 1)
    }
    else {
        return "";
    }
}

//分类树展开/关闭
function categoryTree(obj, layer) {
    var state = $(obj).attr("class");
    if (state == "open") {
        $(obj).parent().parent().nextAll().each(function (index) {
            var flag = parseInt($(this).attr("layer")) - layer;
            if (flag == 1) {
                $(this).show();
            }
            else if (flag == 0) {
                return false;
            }
        })
        if ($(obj).hasClass("open")) {
            $(obj).removeClass("open").addClass("close");
        }
    }
    else if (state == "close") {
        $(obj).parent().parent().nextAll().each(function (index) {
            if (parseInt($(this).attr("layer")) > layer) {
                $(this).hide();
                $(this).find("th span").each(function (i) {
                    if ($(this).attr("class") != "" && $(this).attr("class") != undefined) {
                        $(this).removeClass("close").addClass("open");
                    }
                })
            }
            else {
                return false;
            }
        })
        if ($(obj).hasClass("close")) {
            $(obj).removeClass("close").addClass("open");
        }
    }
}
//分类树展开/关闭
$("#categoryTree tbody tr").each(function () {
    var layer = parseInt($(this).attr("layer")) + 1;
    if ($(this).next("tr[layer='" + layer + "']") == undefined || $(this).next("tr[layer='" + layer + "']").length < 1) {
        if ($(this).find(".close") != undefined && $(this).find(".close").length > 0) {
            $(this).find(".close").attr("class", $(this).find(".close").attr("class").replace("close", ""));
        }
    }
});