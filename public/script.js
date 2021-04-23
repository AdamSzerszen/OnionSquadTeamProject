function sendMail() {
        addres = document.getElementById("inputSpamEmail").value,
        mail = document.getElementById("inputEmailText").value

    fetch(`={"addres":${addres}, "mail":${mail}`, {
        method: 'POST'
    })
    .then(res => {
        return res.text()
    })
    .catch((error)=> {
        alert(error)
    })
}