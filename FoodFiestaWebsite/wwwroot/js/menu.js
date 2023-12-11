var raaagh = document.getElementById("raaagh");
var raaagh2 = document.getElementById("raaagh2");
var userId = localStorage.getItem("userId");

if (userId !== null) {
    raaagh.innerHTML = `
        <a class="user_link">
        <button class="logout-button" onclick="logout()">
            <i class="fa fa-user"></i> LOGOUT
        </button>
    </a>
    `
}
else {
    raaagh2.innerHTML = ` `
}
function logout() {
    localStorage.clear();
    location.reload(true);
}
