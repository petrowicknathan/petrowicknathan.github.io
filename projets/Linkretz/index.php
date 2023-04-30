<!DOCTYPE html>
<html lang="fr-FR">
<head>
	<meta charset="UTF-8">
	<meta name ="viewport" content="width=device-width, initial-scale-1.0">
	<meta name="description" content="Site de l'agence Linkretz">
	<link rel="stylesheet" href="css/style.css">
	<title>Site de l'agence Linkretz - Page d'accueil</title>
</head>	                                                                          
<body>	

		<?php 
			include "include/header.html";
		?>

	<?php include "include/menu_client.html"; ?> 

		<section class="accueil">
			<h2>Qui sommes-nous ?</h2>
			<div class = "sec">
				<p>Une agence familiale située à Chantilly, spécialisée dans la vente de séjours conçus par des tour-opérateurs.<br>
				Nous vous proposons également les services suivants :</p>
				<ul>
					<li>la vente de billets d'avion ou de train ;</li>
					<li>la location de voitures, de villas ou d'appartements, </li>
					<li>la réservation de chambres d'hôtel ;</li>
					<li>l'organisation de voyage à la carte.</li>
				</ul>
			</div>
		</section>
		<section class="">
			<h2>Coordonnées</h2>
			<p class="table">
				6, rue du connétable<br>
				Batiment B<br>
				60500 Chantilly<br><br>
				<strong>+33 3 44 58 52 59</strong><br>
				agence@linkretz.com
			</p>
		</section>
		<section class=" ">
			<h2>Horaires d'ouverture</h2>
			
			<?php 
			include "include/connexion_bd.php";
			//
			try {
				$lesEnregs=$bdd->query("SELECT jour,matin,apres_midi FROM horaire_ouverture");
			
			}catch (PDOException $e) {
				die ("Err BDDSelect : erreur de lecture table horaire d'ouverture dans index.php");
			}
			//
			if($lesEnregs->rowCount () ==0) {
				echo ("Aucun horaire d'ouverture n'a été enregistré");
			} else{
				// 
				echo ("<table>");
				foreach($lesEnregs as $enregs) {
					echo "<strong><tr><td>$enregs->jour</td></strong><strong><td>$enregs->matin</td></strong><strong><td>$enregs->apres_midi</td></tr></strong>";
				}
				echo("</table>");
			}
			?>

		</section>
	<footer>
		<p>Copyright 2019 Linkretz - Toute reproduction interdite 
			<a href="page/mentions_legales.html">Mentions Légales</a>
		</p>
	</footer>
</body>
</html>

