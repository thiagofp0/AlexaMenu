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
            //Pegar data atual e format�-la no padr�o da api da ufv
            //Fazer a requisi��o
            //Criar um objeto que fa�a sentido
            //Desserializar os valores
            //Criar adapter do mongoDB
            //Salvar no mongoDB
            //Requisi��o na api para atualizar singleton
        }
    }
}
