// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

#include "ExperimentsGameMode.h"
#include "ExperimentsPlayerController.h"
#include "ExperimentsPawn.h"

#include "addressbook.pb.h"

AExperimentsGameMode::AExperimentsGameMode()
{
	// no pawn by default
	DefaultPawnClass = AExperimentsPawn::StaticClass();
	// use our own player controller class
	PlayerControllerClass = AExperimentsPlayerController::StaticClass();


	tutorial::AddressBook AddressBook;

	auto* Person = AddressBook.add_people();

	Person->set_name("Name");
	UE_LOG(LogTemp, Warning, TEXT(Person->get_name()));
}

void AExperimentsGameMode::BeginPlay()
{
}
