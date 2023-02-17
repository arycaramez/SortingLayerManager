# Sorting Layer Manager - Unity

<p align="center">
  <img height="250em" src="https://user-images.githubusercontent.com/37397920/219553164-08f29a24-1a3e-4baf-ab8b-cfae233335fd.gif">
  <!--![gif_slg](https://user-images.githubusercontent.com/37397920/219553164-08f29a24-1a3e-4baf-ab8b-cfae233335fd.gif)-->
</p>

É um asset que permite gerenciar as camadas pertencentes às partes de um personagem 2D, ou seja, é um gerenciador de Sorting Layers para personagens 2D. Percebi que assim ficaria mais fácil para trabalhar com sprites 2D, neste asset você pode encontrar uma versão do script compatível com o Asset "Anima 2D" usado para criar rig para personagens 2D.

Esse asset cria uma lista de tags que você pode usar para referenciar os sprites de um personagem/cenário, alterando a ordem na lista de tags você pode gerenciar os ID's de todos os sprites, isso permite fazer um controle de hierarquia de exibição determinando quais sprites devem ficar por cima e quais devem ficar abaixo. Você também pode atribuir um Sorting Layer aos objetos com tags, dessa forma você consegue organizar os sprites de personagens e cenários 2D de forma rápida.

Em menos de 5 minutos de uso é possível entender seu funcionamento, é muito intuitivo.

Obs: Dentro do projeto existe um conteúdo adicional que permite a integração do "SortingLayerManager" com o asset Anima 2D.

## Assets e softwares:
- Unity Version: 2020.02.06.0
- Asset Anima2D Version: 1.1.7 2019-05-23. 

## Modo de uso:

<a target="_blank" href="https://youtu.be/BQ7jp0xBycA">Clique aqui e veja o vídeo tutorial.</a>

## Proximas modificações:
- Irei incluir a opção de modificar sorting layers individualmente através das tags, permitindo que cada objeto tagueado receba uma sorting layer diferente.
- Otimização de código usando os princípios SOLID (em andamento).
- Atualização para a versão mais recente da Unity e seu novo sistema de animação com rig para personagem 2D.
