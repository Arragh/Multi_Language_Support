
let localization;

$(function () {

    let culture = document.getElementById('selectCulture').value

    $.ajax({
        url: '/ajax/HomeAjax/GetResources',
        type: 'GET',
        data: {
            localize: culture
        },
        traditional: true,
        success: async function (result) {

            localization = result
            setLocale()
        },
        error: function (res) {

            console.log('Что-то пошло не так')
            console.log(res)
        }
    })
})

function Localization(locName) {

    return localization.find(v => v.name === locName).value
}

function setLocale() {

    document.getElementById('h1').innerText = Localization('Header')
    document.getElementById('h2').innerText = Localization('Message')
    document.getElementById('h3').innerText = Localization('Message2')
}

function getInfo() {

    let culture = document.getElementById('selectCulture').value

    $.ajax({
        url: '/ajax/HomeAjax/GetResources',
        type: 'GET',
        data: {
            localize: culture
        },
        traditional: true,
        success: async function (result) {

            console.log(result)
        },
        error: function (res) {

            console.log('Что-то пошло не так')
            console.log(res)
        }
    })
}

function testOnChange() {

    let culture = document.getElementById('selectCulture').value

    document.cookie = '.AspNetCore.Culture=c=' + culture + '|uic=' + culture

    console.log('trololo')
}