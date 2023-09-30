
const patterName = /^[a-zA-ZÁáÉéÍíÓóÚúÜüÑñ\s]+$/
const patterPhone = /^[0-9]{10,13}$/
const patterDocument = /^[0-9]{7,10}$/
const patterCorreo = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
const patterGender = /^[M-mF-f]{1,1}$/

function validarName() {

    let name = document.getElementById("inputNombre").value;

    if (!patterName.test(name)) {
        document.getElementById("ErrorNombre").innerHTML = "El numero de nombre  no es valido"
    } else {
        document.getElementById("ErrorNombre").innerHTML = ""
    }

    console.log(name)
}


function validarLastName() {

    let lastName = document.getElementById("inputApellido").value;

    if (!patterName.test(lastName)) {
        document.getElementById("ErrorApellido").innerHTML = "El apellido no es valido"
    } else {
        document.getElementById("ErrorApellido").innerHTML = ""
    }
    console.log(lastName)

}

function validarDocument() {

    let documen = document.getElementById("inputDocumento").value;

    if (!patterDocument.test(documen)) {
        document.getElementById("ErrorDocumento").innerHTML = "El documento no es valido"
    } else {
        document.getElementById("ErrorDocumento").innerHTML = ""
    }

    console.log(documen)
}

function validarGender() {

    let gender = document.getElementById("inputGenero").value;

    if (!patterGender.test(gender)) {
        document.getElementById("ErrorGenero").innerHTML = "El genero no es valido"
    } else {
        document.getElementById("ErrorGenero").innerHTML = ""
    }

    console.log(gender)
}


function validarPhone() {

    let phone = document.getElementById("inputTelefono").value;

    if (!patterPhone.test(phone)) {
        document.getElementById("ErrorPhone").innerHTML = "El numero de telefono no es valido"
    } else {
        document.getElementById("ErrorPhone").innerHTML = ""
    }

    console.log(phone)
}

function validarEmail() {

    let email = document.getElementById("inputCorreo").value;

    if (!patterCorreo.test(email)) {
        document.getElementById("ErrorCorreo").innerHTML = "El Correo es invalido"
    } else {
        document.getElementById("ErrorCorreo").innerHTML = ""
    }
    console.log(email)

}


