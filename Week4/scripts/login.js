function validate() {
    let username = document.getElementById('username').value;
    let password = document.getElementById('password').value;

    console.debug('Username: ' + username);
    console.debug('Password: ' + password);

    if (username == '' || password == '') {
        emptyFieldError();
    }

    document.cookie = `username=${username}; expires=31 Dec 2024 12:00:00 UTC; path=/`;
}

function showPassword() {
    var x = document.getElementById("password");
    if (x.type === "password") {
      x.type = "text";
    } else {
      x.type = "password";
    }
  }

function emptyFieldError() {
    window.alert("Either your Username or Password field is blank.");
}