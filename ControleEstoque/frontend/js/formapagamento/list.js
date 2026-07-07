async function carregarPagamento() {
    try {
        const response = await fetch(`${API_BASE_URL}/FormaPagamento`, {
            method: 'GET',
            headers: getHeaders()
        });

        if(response.status == 401) {
            // rediraciona para o login, remove o token
            alert("Sessão expirada! Por favor, faça login novamente!");
            localStorage.removeItem('token');
            window.location.href = '/index.html';
        } else if (response.status == 403) {
            alert("Acesso negado! Você não tem permissão para acessar esta página.");
            window.location.href = '../../index.html'; // redireciona para o index
            // alerta em tela, "NÃO AUTORIZADO", redireciona para o index
        }

        const pagamentos = await response.json();
        
        const tbody = document.getElementById('tabela-formapagamento');
        tbody.innerHTML = '';

        pagamentos.forEach(pagamento => {
            const tr = document.createElement('tr');
            tr.innerHTML = `
                <td>${pagamento.id}</td>
                <td>${pagamento.descricao}</td>
                <td class="actions">
                    <a href="detalhes.html?id=${pagamento.id}">Detalhes</a>
                    <a href="form.html?id=${pagamento.id}">Editar</a>
                    <a href="excluir.html?id=${pagamento.id}" style="color: var(--danger-color);">Excluir</a>
                </td>
            `;
            tbody.appendChild(tr);
        });
    }   catch (error) {
        console.error("Erro ao carregar as formas de pagamento:", error);
    }

}

carregarPagamento();