// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/GameModeBase.h"
#include "ExperimentsGameMode.generated.h"

/** GameMode class to specify pawn and playercontroller */
UCLASS(minimalapi)
class AExperimentsGameMode : public AGameModeBase
{
	GENERATED_BODY()

public:
	AExperimentsGameMode();
	virtual void BeginPlay() override;
};



