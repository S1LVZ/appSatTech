-- Inserindo Dados Iniciais para Teste
INSERT INTO Cliente (Nome, CPF, Telefone, DataNascimento) VALUES 
('Maria Oliveira', '111.222.333-44', '(11) 98888-7777', '1990-05-15'),
('João Souza', '555.666.777-88', '(11) 97777-6666', '1985-10-20');

INSERT INTO Tecnico (Nome, RegistroTecnico, Especialidade) VALUES 
('Dra. Helena Rios', 'TEC/SP 123456', 'Redes de Computadores'),
('Dr. Roberto Alves', 'TEC/SP 654321', 'Manutenção de Hardware');

INSERT INTO Chamado (DataHora, StatusAtendimento, ClienteID, TecnicoID) VALUES 
('20261015 14:00:00', 'Agendada', 1, 1),
('20261016 09:30:00', 'Agendada', 2, 2);
GO

use dbTecnico

select * from Cliente
select * from Tecnico
select * from Chamado