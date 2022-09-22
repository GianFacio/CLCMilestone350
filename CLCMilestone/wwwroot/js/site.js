$(document).on('click', '.restart', function (e)
{
	$.ajax({
		url: '/gameboard/SetGameBoard',
		type: 'POST',
		data: {
			"boardSetup": $(this).val()
		},
		success: function (data) {
			$("body").html(data);
		}
	});
})

$(document).on('click', '.load-button', function (e)
{
	$.ajax({
		url: '/gameboard/LoadBoard',
		type: 'GET',
		success: function (data) {
			alert(data);
		}
	});
})

$(document).on('mousedown', '.game-button', function (e)
{
	switch (e.which)
	{
		case 1:
			$.ajax({
				url: '/gameboard/UpdateBoard',
				type: 'POST',
				data:
				{
					"cell": $(this).val()
				},
				success: function (data)
				{
					$(".pb-3").html(data);
				}
			});

			break;
		case 2:
			break;
		case 3:
			$.ajax({
				url: '/gameboard/FlagHandler',
				type: 'POST',
				data:
				{
					"cell": $(this).val()
				},
				dataType: 'html',
				success: function (data)
				{
					$(".pb-3").html(data);
				},
				error: function ()
				{
					alert('Failed');
				}
			});
			break;
		default:
			console.log("Failed");
			break;
	}
})
