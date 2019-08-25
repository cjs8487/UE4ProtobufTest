// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

#include "ExperimentsPlayerController.h"

AExperimentsPlayerController::AExperimentsPlayerController()
{
	bShowMouseCursor = true;
	bEnableClickEvents = true;
	bEnableTouchEvents = true;
	bEnableMouseOverEvents = true;
	DefaultMouseCursor = EMouseCursor::Crosshairs;
}
