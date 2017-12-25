//stores all functions for animations

function animImageDec() {
	if (imageIndex > 1)
		imageIndex--;
	else
		imageIndex = numOfImages;
}

function setCurrImage() {
	document.MainImage.src = imgarray[imageIndex].src;
}

function updateAnim() {

	if (aktualnieWyswietlanaAnimacja == 'larry_list'
			&& aktualnaStrona == 'pre-rental-checklist') {

		timeoutValue = 100;
		animDelay = 1000;
	
	} else {
		timeoutValue = 100;
		animDelay = 900;
	}

	var currTimeoutValue;

	currTimeoutValue = timeoutValue;

	if (playMode == 1) {
		animImageInc();
		if (imageIndex == numOfImages)
			currTimeoutValue += animDelay;
	} else {
		animImageDec();
		if (imageIndex == 1)
			currTimeoutValue += animDelay;
	}

	if (playMode != 2) {

		clearTimeout(timeoutID);
		setCurrImage();
		timeoutID = setTimeout("updateAnim()", currTimeoutValue);
	}
}

function clearLastUpdate() {
	clearTimeout(timeoutID);
	timeoutID = 0;
}

function startPlay() {
	clearLastUpdate();
	playMode = 1;
	updateAnim();
}

function startPlayReverse() {
	clearLastUpdate();
	playMode = 2;
	updateAnim();
}

function animImageInc_2() {
	if (imageIndex_2 < numOfImages_2)
		imageIndex_2++
	else
	{
		// stop animation

		if (aktualnaStrona == 'using-letting-agency'
				|| aktualnaStrona == 'signing-tenancy-agreement'
				|| aktualnaStrona == 'finding-tradesman'
				|| aktualnaStrona == 'gas-safety-checks'
				|| aktualnaStrona == 'tax-on-rental-profits'
				|| aktualnaStrona == 'evicting-tenants')
			playMode_2 = 2;
		else if (aktualnaStrona == 'getting-landlord-insurance') {
			// larry and lenny talking

			if (gli_is_takling == 'lenny' && animationsCircleCounter_2 >= 2)
				playMode_2 = 2;
		}

		imageIndex_2 = 1;
		animationsCircleCounter_2++;
	}
}

function animImageDec_2() {
	if (imageIndex_2 > 1)
		imageIndex_2--;
	else
		imageIndex_2 = numOfImages_2;
}

function setCurrImage_2() {
	document.MainImage_2.src = imgarray_2[imageIndex_2].src;
}

function updateAnim_2() {
	var currTimeoutValue;

	currTimeoutValue = timeoutValue_2;

	timeoutValue_2 = 100;
	animDelay_2 = 900;

	if (playMode_2 == 1) {
		animImageInc_2();
		if (imageIndex_2 == numOfImages_2)
			currTimeoutValue += animDelay_2;
	}

	setCurrImage_2();
	clearTimeout(timeoutID_2);
	timeoutID_2 = setTimeout("updateAnim_2()", currTimeoutValue);
}

function clearLastUpdate_2() {
	clearTimeout(timeoutID_2);
	timeoutID_2 = 0;
}

function startPlay_2() {
	clearLastUpdate_2();
	playMode_2 = 1;
	updateAnim_2();
}

function startPlayReverse_2() {
	clearLastUpdate_2();
	playMode_2 = 2;
	updateAnim_2();
}

// 3 animacja - big larry

function animImageInc_3() {
	if (imageIndex_3 < numOfImages_3)
		imageIndex_3++
	else
		imageIndex_3 = 1;
}

function animImageDec_3() {
	if (imageIndex_3 > 1)
		imageIndex_3--;
	else
		imageIndex_3 = numOfImages_3;
}

function setCurrImage_3() {
	document.MainImage_3.src = imgarray_3[imageIndex_3].src;
}

function updateAnim_3() {
	var currTimeoutValue;

	currTimeoutValue = timeoutValue_3;

	timeoutValue_3 = 100;
	animDelay_3 = 900;

	animImageInc_3();
	if (imageIndex_3 == numOfImages_3)
		currTimeoutValue += animDelay_3;

	setCurrImage_3();
	clearTimeout(timeoutID_3);
	timeoutID_3 = setTimeout("updateAnim_3()", currTimeoutValue);
}

function clearLastUpdate_3() {
	clearTimeout(timeoutID_3);
	timeoutID_3 = 0;
}

function startPlay_3() {
	clearLastUpdate_3();
	playMode_3 = 1;
	updateAnim_3();
}

function startPlayReverse_3() {
	clearLastUpdate_3();
	playMode_3 = 2;
	updateAnim_3();
}
