<!DOCTYPE html>
<html lang="fr-FR">
<head>
	<meta charset="UTF-8">
	<meta name ="viewport" content="width=device-width, initial-scale-1.0">
	<meta name="description" content="Site de l'agence Linkretz">
	<link rel="stylesheet" href="../css/style.css">
	<title>Site de l'agence Linkretz - Liste des tour-opérateurs</title>
</head>
<body>
		<?php 
			include $_SERVER['DOCUMENT_ROOT'].'/include/footer.html';
		?>
		
	<?php include "include/menu_client.html"; ?> 

	<section class="tour-operateurs">
		<h2>Tour-opérateurs avec lesquels nous travaillons</h2>
		<div class="sec">
			<?php
			include "../include/connexion_bd.php";
			//execution de la requête
			try{
				$lesEnregs=$bdd->query("SELECT nom, description, libelle FROM tour_operateur JOIN specialite ON id_specialite = specialite.id");
			} catch(PDOException $e) {
				die("Err BDSelect; erreur de lecture table tour_operateur dans tour_operateur_consult.php<br>Message d'erreur :" . $e->getMessage());
			}
			//on test si le Select a retourné des enregistrements
			if($lesEnregs->rowCount () ==0) {
				echo  ("Aucun tour-opérateur n'a été enregistré");
			} else {
				//on lit le tableau retourné et pour chaque enregistrement, on affiche le nom et la description
				foreach ($lesEnregs as $enreg) {
					echo "<strong>$enreg->nom / $enreg->libelle</strong><br>$enreg->description<br><br>";
				
				}
			}
			?>
		</div>
	</section>
	<footer>
		<p>Copyright 2019 Linkretz - Toute reproduction interdite 
			<a href="mentions_legales.html">Mentions Légales</a>
		</p>
	</footer>
</body>
</html>