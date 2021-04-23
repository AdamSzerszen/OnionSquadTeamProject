function sendMail() {
        const addres = document.getElementById("inputSpamEmail").value
        const mail = document.getElementById("inputEmailText").value
        const sendDate = document.getElementById("sendDate").value
        const sendTime = document.getElementById("sendTime").value
        const data = {addres, mail, sendDate, sendTime}
        

    fetch(`={"addres":${addres}, "mail":${mail}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
          },
        body: JSON.stringify(data)
    })
    .then(res => {
        return res.text()
    })
    .catch((error)=> {
        alert(`Error: ${error}`)
    })
}