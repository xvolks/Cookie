package com.ankamagames.dofus.network.messages.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.character.CharacterMinimalInformations;
   import com.ankamagames.dofus.network.types.game.context.fight.FightCommonInformations;
   import com.ankamagames.dofus.network.types.game.context.fight.FightStartingPositions;
   import com.ankamagames.dofus.network.types.game.context.roleplay.GameRolePlayActorInformations;
   import com.ankamagames.dofus.network.types.game.house.HouseInformations;
   import com.ankamagames.dofus.network.types.game.interactive.InteractiveElement;
   import com.ankamagames.dofus.network.types.game.interactive.MapObstacle;
   import com.ankamagames.dofus.network.types.game.interactive.StatedElement;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MapComplementaryInformationsDataInHavenBagMessage extends MapComplementaryInformationsDataMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6622;
       
      
      private var _isInitialized:Boolean = false;
      
      public var ownerInformations:CharacterMinimalInformations;
      
      public var theme:int = 0;
      
      public var roomId:uint = 0;
      
      public var maxRoomId:uint = 0;
      
      private var _ownerInformationstree:FuncTree;
      
      public function MapComplementaryInformationsDataInHavenBagMessage()
      {
         this.ownerInformations = new CharacterMinimalInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6622;
      }
      
      public function initMapComplementaryInformationsDataInHavenBagMessage(param1:uint = 0, param2:uint = 0, param3:Vector.<HouseInformations> = null, param4:Vector.<GameRolePlayActorInformations> = null, param5:Vector.<InteractiveElement> = null, param6:Vector.<StatedElement> = null, param7:Vector.<MapObstacle> = null, param8:Vector.<FightCommonInformations> = null, param9:Boolean = false, param10:FightStartingPositions = null, param11:CharacterMinimalInformations = null, param12:int = 0, param13:uint = 0, param14:uint = 0) : MapComplementaryInformationsDataInHavenBagMessage
      {
         super.initMapComplementaryInformationsDataMessage(param1,param2,param3,param4,param5,param6,param7,param8,param9,param10);
         this.ownerInformations = param11;
         this.theme = param12;
         this.roomId = param13;
         this.maxRoomId = param14;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.ownerInformations = new CharacterMinimalInformations();
         this.roomId = 0;
         this.maxRoomId = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_MapComplementaryInformationsDataInHavenBagMessage(param1);
      }
      
      public function serializeAs_MapComplementaryInformationsDataInHavenBagMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_MapComplementaryInformationsDataMessage(param1);
         this.ownerInformations.serializeAs_CharacterMinimalInformations(param1);
         param1.writeByte(this.theme);
         if(this.roomId < 0)
         {
            throw new Error("Forbidden value (" + this.roomId + ") on element roomId.");
         }
         param1.writeByte(this.roomId);
         if(this.maxRoomId < 0)
         {
            throw new Error("Forbidden value (" + this.maxRoomId + ") on element maxRoomId.");
         }
         param1.writeByte(this.maxRoomId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MapComplementaryInformationsDataInHavenBagMessage(param1);
      }
      
      public function deserializeAs_MapComplementaryInformationsDataInHavenBagMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.ownerInformations = new CharacterMinimalInformations();
         this.ownerInformations.deserialize(param1);
         this._themeFunc(param1);
         this._roomIdFunc(param1);
         this._maxRoomIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MapComplementaryInformationsDataInHavenBagMessage(param1);
      }
      
      public function deserializeAsyncAs_MapComplementaryInformationsDataInHavenBagMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._ownerInformationstree = param1.addChild(this._ownerInformationstreeFunc);
         param1.addChild(this._themeFunc);
         param1.addChild(this._roomIdFunc);
         param1.addChild(this._maxRoomIdFunc);
      }
      
      private function _ownerInformationstreeFunc(param1:ICustomDataInput) : void
      {
         this.ownerInformations = new CharacterMinimalInformations();
         this.ownerInformations.deserializeAsync(this._ownerInformationstree);
      }
      
      private function _themeFunc(param1:ICustomDataInput) : void
      {
         this.theme = param1.readByte();
      }
      
      private function _roomIdFunc(param1:ICustomDataInput) : void
      {
         this.roomId = param1.readByte();
         if(this.roomId < 0)
         {
            throw new Error("Forbidden value (" + this.roomId + ") on element of MapComplementaryInformationsDataInHavenBagMessage.roomId.");
         }
      }
      
      private function _maxRoomIdFunc(param1:ICustomDataInput) : void
      {
         this.maxRoomId = param1.readByte();
         if(this.maxRoomId < 0)
         {
            throw new Error("Forbidden value (" + this.maxRoomId + ") on element of MapComplementaryInformationsDataInHavenBagMessage.maxRoomId.");
         }
      }
   }
}
