using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AlexaMenu.DataCapture
{
    public class DataCapture
    {

        [Function("DataCapture")]
        public void Run([TimerTrigger("%schedule%")] FunctionContext context)
        {
            //Pegar data atual e formatá-la no padrão da api da ufv
            //Fazer a requisição
            //Criar um objeto que faça sentido
            //Desserializar os valores
            //Criar adapter do mongoDB
            //Salvar no mongoDB
            //Requisição na api para atualizar singleton
        }
    }
}
