<!DOCTYPE html>
<html lang="fr-FR">
<head>
	<meta charset="UTF-8">
	<meta name ="viewport" content="width=device-width, initial-scale-1.0">
	<meta name="description" content="Site de l'agence Linkretz">
	<link rel="stylesheet" href="../css/style.css">
	<title>Site de l'agence Linkretz - Liste des commerciaux</title>
</head>
<body>
		<?php 
			include $_SERVER['DOCUMENT_ROOT'].'/include/footer.html';
		?>
		
	<?php include "include/menu_client.html"; ?> 

	<section class="comm">
		<h2>Commerciaux à contacter</h2>
		<div class="sec">
			<p> 
			<?php 
			include "../include/connexion_bd.php";
			// 
			try { 
				$lesEnregs=$bdd->query("SELECT nom,prenom,telephone FROM employe JOIN fonction ON idfonction = fonction.id WHERE libelle = 'commercial'");
			 
			}catch (PDOException $e) {
				die ("Err BDDSelect : erreur de lecture table employe dans employe_consult_client.php");
			}
			//
			if($lesEnregs->rowCount () ==0) {
				echo ("Aucun des employés commerciaux n'a été enregistré");
			} else{ 
				// 
				echo ("<table> 
					<tr> 
						<th>nom</th> 
						<th>prenom</th> 
						<th>telephone</th> 
					</tr>"); 
				foreach($lesEnregs as $enregs) { 
					echo "<strong><tr><td>$enregs->nom</td></strong><strong><td>$enregs->prenom</td></strong><strong><td>$enregs->telephone</td></tr></strong>";
				} 
				echo("</table>"); 
			}
			?>
			</p>
		</div>
	</section>
	<footer>
		<p>Copyright 2019 Linkretz - Toute reproduction interdite 
			<a href="mentions_legales.html">Mentions Légales</a>
		</p>
	</footer>
</body>
</html>



