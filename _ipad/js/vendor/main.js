// JavaScript Document		
$(document).ready(function() {

	/*Project Sort*/
	  // get the action filter option item on page load
  var $filterType = $('.filter_project li.selected a').attr('class');
	
  // get and assign the ourHolder element to the
	// $holder varible for use later
  var $holder = $('ul.project_list');

  // clone all items within the pre-assigned $holder element
  var $data = $holder.clone();

  // attempt to call Quicksand when a filter option
	// item is clicked
	$('.filter_project li a').click(function(e) {
		// reset the active class on all the buttons
		$('.filter_project li').removeClass('selected');		
		// assign the class of the clicked filter option
		// element to our $filterType variable
		var $filterType = $(this).attr('class');
		$(this).parent().addClass('selected');
		
		if ($filterType == 'all') {
			// assign all li items to the $filteredData var when
			// the 'All' filter option is clicked
			var $filteredData = $data.find('li');
		} 
		else {
			// find all li elements that have our required $filterType
			// values for the data-type element
			var $filteredData = $data.find('li[data-type=' + $filterType + ']');
		}
		
		// call quicksand and assign transition parameters
		$holder.quicksand($filteredData, {duration: 800, easing: 'easeInOutQuad'}, function(){
			initTip();
			initPop();
		});
		
		return false;
	});	
	
	
	
    });	