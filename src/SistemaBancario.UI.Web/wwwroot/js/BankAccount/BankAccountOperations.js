class BankAccountOperations {
    constructor() {
        console.log("Instancia de BankAccountOperations Criada.");

        document.addEventListener("DOMContentLoaded", event => {

            document.getElementById("btnSacar").addEventListener("click", this.Transaction);

            document.getElementById("btnDepositar").addEventListener("click", this.Transaction);

            document.getElementById("btnPagar").addEventListener("click", this.Transaction);
        });
    }

    async Transaction(event) {
        event.preventDefault();
        const operation = event.target.dataset.operation;

        console.log("Iniciando saque.")

        const data = {
            value: parseFloat(document.getElementById("inputValue").value) || 0
        }

        console.log("Enviando requisição AJAX");
        const url = `/api/BankAccount/${operation}`;
        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        const response = await fetch(url, {
            method: "POST",
            body: JSON.stringify(data),
            headers: myHeaders
        })
        const result = await response.json();

        console.log("Validando Reposta");
        if (result && response.status == 200) {
            confirm("Operação realizada com sucesso.")
            window.location.reload();
        } else {
            const errors = result.errors.Value.join(".\n");
            alert(errors);
        }
    }
}

new BankAccountOperations();
