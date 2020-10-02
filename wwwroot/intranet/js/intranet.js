function SubmitLoading() {
    var $ = layui.$;
    $('.submit_loading').css({ 'display': 'block' });
}

function UnSubmitLoding() {
    var $ = layui.$;
    $('.submit_loading').css({ 'display': 'none' });
}

function MobileTreeButton() {
    var element = layui.element;
    var $ = layui.$;

    //手机设备的简单适配
    $('.site-tree-mobile').on('click', function () {
        $('body').addClass('site-mobile');
    });

    $('.site-mobile-shade').on('click', function () {
        $('body').removeClass('site-mobile');
    });
}

function ApplyFormElder() {
    var form = layui.form;
    var laydate = layui.laydate;
    var element = layui.element;
    var $ = layui.jquery;
    var layer = layui.layer;

    laydate.render({
        elem: '#date1'
    });

    laydate.render({
        elem: '#date2'
    });
}

function ApplyFormVolunteer() {
    var form = layui.form;
    var laydate = layui.laydate;
    var element = layui.element;
    var $ = layui.jquery;
    var layer = layui.layer;

    laydate.render({
        elem: '#date1'
    });
}

// 检查图片大小不超过4M
function CheckSizeMax4M(input) {
    var layer = layui.layer;

    let size = input.files[0].size;
    size = size / 1024; //KB
    if (size > 4096) {
        input.value = '';
        layer.alert("图片大小不能超过4M");
    }
}

// 清除所有input
function ClearAllInput() {
    var inputs = document.getElementsByTagName("input");
    for (var i = 0; i < inputs.length; i++) {
        inputs[i].value = "";
    }
}

/* Page Load */
// Elder/Index
function Page_Elder_Index() {
    Elder_LiveAtListJson('Index');
}

// Elder/Create
function Page_Elder_CreateNew() {
    var laydate = layui.laydate;
    laydate.render({
        elem: '#date1'
    });
}

// Elder/Edit
function Page_Elder_Edit() {
    var laydate = layui.laydate;
    laydate.render({
        elem: '#date1'
    });
}

// Elder/ToContract
function Page_Elder_ToContract() {
    var laydate = layui.laydate;
    laydate.render({
        elem: '#date1'
    });
}

// Elder/ToLeft
function Page_Elder_ToLeft() {
    var laydate = layui.laydate;
    laydate.render({
        elem: '#date1'
    });
}

// Elder/IndexLeft
function Page_Elder_IndexLeft() {
    ElderL_LeftListJson('IndexLeft');
}

// Elder/IndexDelete
function Page_Elder_IndexDelete() {
    Elder_AllListJson('IndexDelete');
}
/* Page Load End*/

/* Table Json Data*/
// 获取 所有 老人 list json
function Elder_AllListJson(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Elder/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['prev', 'page', 'next', 'count', 'limit']
            , groups: 3
        }
        , where: { handler: "AllListJson" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'identity', title: '身份证', width: '180'}
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'liveState', title: '住院状态' }
            , { field: 'experienceStartDate', title: '体验开始日' }
            , { field: 'experienceEndDate', title: '体验结束日' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl'}
        ]]
    });
    return tableIns;
}

// 获取 入住 老人 list json
function Elder_LiveAtListJson(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Elder/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['prev', 'page', 'next', 'count', 'limit']
            , groups: 3
        }
        , where: { handler: "LiveAtListJson" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'liveState', title: '住院状态' }
            , { field: 'experienceStartDate', title: '体验开始日' }
            , { field: 'experienceEndDate', title: '体验结束日' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 获取 体验 老人 list json
function Elder_ExperienceListJson(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Elder/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['prev', 'page', 'next', 'count', 'limit']
            , groups: 3
        }
        , where: { handler: "ExperienceListJson" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'experienceStartDate', title: '体验开始日' }
            , { field: 'experienceEndDate', title: '体验结束日' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'liveState', title: '住院状态' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 获取 合约 老人 list json
function Elder_ContractListJson(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Elder/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['prev', 'page', 'next', 'count', 'limit']
            , groups: 3
        }
        , where: { handler: "ContractListJson" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'liveState', title: '住院状态' }
            , { field: 'experienceStartDate', title: '体验开始日' }
            , { field: 'experienceEndDate', title: '体验结束日' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 获取 退住 老人 list json
function ElderL_LeftListJson(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Elder/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['prev', 'page', 'next', 'count', 'limit']
            , groups: 3
        }
        , where: { handler: "LeftListJson" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'leftDate', title: '退住日期' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'liveState', title: '住院状态' }
            , { field: 'experienceStartDate', title: '体验开始日' }
            , { field: 'experienceEndDate', title: '体验结束日' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 获取 体验 到期 list json
function Elder_ExperienceListJson_Expire(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Elder/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count'] /*['prev', 'page', 'next', 'count', 'limit']*/
            //, groups: 3 //只显示 3 个连续页码
        }
        , where: { handler: "ExperienceListJson_Expire" } //url 其他参数
        /* , request: { pageName: 'pages' }*/ /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'experienceStartDate', title: '体验开始日' }
            , { field: 'experienceEndDate', title: '体验结束日' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'liveState', title: '住院状态' }
            , { field: 'contractStartDate', title: '合约开始日'}
            , { field: 'contractEndDate', title: '合约结束日'}
            , { field: 'idAddress', title: '户籍地址'}
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 获取 合约 到期 list json
function Elder_ContractListJson_Expire(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Elder/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count'] /*['prev', 'page', 'next', 'count', 'limit']*/
            //, groups: 3 //只显示 3 个连续页码
        }
        , where: { handler: "ContractListJson_Expire" } //url 其他参数
        /* , request: { pageName: 'pages' }*/ /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'contractStartDate', title: '合约开始日'}
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'liveState', title: '住院状态' }
            , { field: 'experienceStartDate', title: '体验开始日' }
            , { field: 'experienceEndDate', title: '体验结束日' }
            , { field: 'idAddress', title: '户籍地址', width: '200' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 搜索 老人 list json by Name
function Elder_SearchNameListJson(page) {
    var table = layui.table;
    var $ = layui.jquery;

    var arg1 = $('#nameInput').val();

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Elder/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['prev', 'page', 'next', 'count', 'limit']
            , groups: 3
        }
        , where: { handler: "SearchNameListJson", elderName: arg1 } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'identity', title: '身份证', width: '180'}
            , { field: 'liveState', title: '住院状态' }
            , { field: 'experienceStartDate', title: '体验开始日' }
            , { field: 'experienceEndDate', title: '体验结束日' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'leftDate', title: '退住日期' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 搜索 老人 list json by Age
function Elder_SearchAgeListJson(page) {
    var table = layui.table;
    var $ = layui.jquery;

    var arg1 = $('#ageInput').val();

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Elder/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count'] /*['prev', 'page', 'next', 'count', 'limit']*/
            //, groups: 3 //只显示 3 个连续页码
        }
        , where: { handler: "SearchAgeListJson", Age: arg1 } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'liveState', title: '住院状态' }
            , { field: 'experienceStartDate', title: '体验开始日' }
            , { field: 'experienceEndDate', title: '体验结束日' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 搜索 老人 list json by IDAddress
function Elder_SearchIDAddressListJson(page) {
    var table = layui.table;
    var $ = layui.jquery;

    var arg1 = $('#idAddressInput').val();

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Elder/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count'] /*['prev', 'page', 'next', 'count', 'limit']*/
            //, groups: 3 //只显示 3 个连续页码
        }
        , where: { handler: "SearchIDAddressListJson", IDAddress: arg1 } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'idAddress', title: '户籍地址' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'liveState', title: '住院状态' }
            , { field: 'experienceStartDate', title: '体验开始日' }
            , { field: 'experienceEndDate', title: '体验结束日' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 搜索 老人 list json by BirthDay
function Elder_SearchBirthMonthListJson(page) {
    var table = layui.table;
    var $ = layui.jquery;

    var arg1 = $('#birthMonthInput').val();

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Elder/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count'] /*['prev', 'page', 'next', 'count', 'limit']*/
            //, groups: 3 //只显示 3 个连续页码
        }
        , where: { handler: "SearchBirthMonthListJson", BirthMonth: arg1 } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'birthDay', title: '生日' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'liveState', title: '住院状态' }
            , { field: 'experienceStartDate', title: '体验开始日' }
            , { field: 'experienceEndDate', title: '体验结束日' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}
/* Table JsonData End*/

/* 员工 Page*/
function Page_Staff_Create() {
    var laydate = layui.laydate;
    laydate.render({
        elem: '#date1'
    });
}

function Page_Staff_Index() {
    Staff_WorkingList("Index");
}

function Page_Staff_Edit() {
    var laydate = layui.laydate;
    laydate.render({
        elem: '#date1'
    });
    laydate.render({
        elem: '#date2'
    });
    laydate.render({
        elem: '#date3'
    });
}

function Page_Staff_IndexDelete() {
    Staff_AllList("IndexDelete");
}


/* 员工 Json Data*/

// 所有员工list
function Staff_AllList(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Staff/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count']//layout: ['prev', 'page', 'next', 'count', 'limit']
            //, groups: 3
        }
        , where: { handler: "AllListJson" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'positionState', title: '岗位状态' }
            , { field: 'workingAge', title: '工龄' }
            , { field: 'workStartDate', title: '入职日期' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 所有 在职员工 list
function Staff_WorkingList(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Staff/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count']//layout: ['prev', 'page', 'next', 'count', 'limit']
            //, groups: 3
        }
        , where: { handler: "WorkingListJson" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'positionState', title: '岗位状态' }
            , { field: 'workingAge', title: '工龄' }
            , { field: 'workStartDate', title: '入职日期' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 所有 试用期 list
function Staff_ProbationList(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Staff/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count']//layout: ['prev', 'page', 'next', 'count', 'limit']
            //, groups: 3
        }
        , where: { handler: "ProbationListJson" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'positionState', title: '岗位状态' }
            , { field: 'workingAge', title: '工龄' }
            , { field: 'workStartDate', title: '入职日期' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }            
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 所有 短期员工 list
function Staff_ShortTermList(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Staff/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count']//layout: ['prev', 'page', 'next', 'count', 'limit']
            //, groups: 3
        }
        , where: { handler: "ShortTermListJson" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'positionState', title: '岗位状态' }
            , { field: 'workingAge', title: '工龄' }
            , { field: 'workStartDate', title: '入职日期' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 所有 长期员工 list
function Staff_ContractList(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Staff/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count']//layout: ['prev', 'page', 'next', 'count', 'limit']
            //, groups: 3
        }
        , where: { handler: "ContractListJson" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'positionState', title: '岗位状态' }
            , { field: 'workingAge', title: '工龄' }
            , { field: 'workStartDate', title: '入职日期' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }                       
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 所有 离职员工 list
function Staff_LeftList(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Staff/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count']//layout: ['prev', 'page', 'next', 'count', 'limit']
            //, groups: 3
        }
        , where: { handler: "LeftListJson" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'workStartDate', title: '入职日期' }
            , { field: 'leftDate', title: '离职日期' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'positionState', title: '岗位状态' }
            , { field: 'workingAge', title: '工龄' }           
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 所有 试用 到期
function Staff_ProbationList_Expire(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Staff/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count']//layout: ['prev', 'page', 'next', 'count', 'limit']
            //, groups: 3
        }
        , where: { handler: "ProbationListJson_Expire" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'positionState', title: '岗位状态' }
            , { field: 'workingAge', title: '工龄' }
            , { field: 'workStartDate', title: '入职日期' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 所有 长期 到期
function Staff_ContractList_Expire(page) {
    var table = layui.table;
    //var $ = layui.jquery;

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Staff/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count']//layout: ['prev', 'page', 'next', 'count', 'limit']
            //, groups: 3
        }
        , where: { handler: "ContractListJson_Expire" } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'positionState', title: '岗位状态' }
            , { field: 'workingAge', title: '工龄' }
            , { field: 'workStartDate', title: '入职日期' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 搜索 在职员工 出生月
function Staff_SearchBirthMonthListJson(page) {
    var table = layui.table;
    var $ = layui.jquery;

    var arg1 = $('#birthMonthInput').val();

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Staff/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count']//layout: ['prev', 'page', 'next', 'count', 'limit']
            //, groups: 3
        }
        , where: { handler: "SearchBirthMonthListJson", BirthMonth: arg1 } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }            
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'positionState', title: '岗位状态' }
            , { field: 'workingAge', title: '工龄' }
            , { field: 'workStartDate', title: '入职日期' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }
            , { field: 'idAddress', title: '户籍地址' }
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}

// 搜索 在职员工 户籍地址
function Staff_SearchIDAddressListJson(page) {
    var table = layui.table;
    var $ = layui.jquery;

    var arg1 = $('#idAddressInput').val();

    var tableIns = table.render({
        elem: '#table1'
        , url: '/Staff/' + page
        , cellMinWidth: 150
        , page: {
            layout: ['count']//layout: ['prev', 'page', 'next', 'count', 'limit']
            //, groups: 3
        }
        , where: { handler: "SearchIDAddressListJson", IDAddress: arg1 } //url 其他参数
        , request: { pageName: 'pages' } /*页码的参数名称，默认：page*/
        , cols: [[
            { field: 'name', title: '姓名' }
            , { field: 'idAddress', title: '户籍地址' }
            , { field: 'sex', title: '性别' }
            , { field: 'age', title: '年龄' }
            , { field: 'phone', title: '电话' }
            , { field: 'birthDate', title: '出生日期' }
            , { field: 'identity', title: '身份证', width: '180' }
            , { field: 'jiGuan', title: '籍贯' }
            , { field: 'positionState', title: '岗位状态' }
            , { field: 'workingAge', title: '工龄' }
            , { field: 'workStartDate', title: '入职日期' }
            , { field: 'contractStartDate', title: '合约开始日' }
            , { field: 'contractEndDate', title: '合约结束日' }           
            , { fixed: 'right', title: '', toolbar: '#caoZuoTpl' }
        ]]
    });
    return tableIns;
}