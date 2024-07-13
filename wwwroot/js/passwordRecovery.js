document.addEventListener("DOMContentLoaded", function () {
  var modal = document.getElementById("passwordRecoveryModal");
  var btn = document.getElementById("forgotPasswordLink");
  var span = document.getElementsByClassName("close")[0];

  btn.onclick = function () {
    modal.style.display = "block";
  };

  span.onclick = function () {
    modal.style.display = "none";
  };

  window.onclick = function (event) {
    if (event.target == modal) {
      modal.style.display = "none";
    }
  };

  document.getElementById("passwordRecoveryForm").onsubmit = function (e) {
    e.preventDefault();
    var email = document.getElementById("recovery__email").value;

    fetch(
      '/api/RecuperacionContraseñaApi/enviarCorreoRecuperacion',
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ correo: email }),
      }
    )
      .then((response) => response.json())
      .then((data) => {
        alert("Email sent successfully!");
        modal.style.display = "none";
      })
      .catch((error) => {
        console.error("Error sending email:", error);
      });
  };
});
