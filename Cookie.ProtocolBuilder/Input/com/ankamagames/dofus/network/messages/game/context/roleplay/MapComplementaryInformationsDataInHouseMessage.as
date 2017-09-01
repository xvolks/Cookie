package com.ankamagames.dofus.network.messages.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.context.fight.FightCommonInformations;
   import com.ankamagames.dofus.network.types.game.context.fight.FightStartingPositions;
   import com.ankamagames.dofus.network.types.game.context.roleplay.GameRolePlayActorInformations;
   import com.ankamagames.dofus.network.types.game.house.HouseInformations;
   import com.ankamagames.dofus.network.types.game.house.HouseInformationsInside;
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
   public class MapComplementaryInformationsDataInHouseMessage extends MapComplementaryInformationsDataMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6130;
       
      
      private var _isInitialized:Boolean = false;
      
      public var currentHouse:HouseInformationsInside;
      
      private var _currentHousetree:FuncTree;
      
      public function MapComplementaryInformationsDataInHouseMessage()
      {
         this.currentHouse = new HouseInformationsInside();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6130;
      }
      
      public function initMapComplementaryInformationsDataInHouseMessage(param1:uint = 0, param2:uint = 0, param3:Vector.<HouseInformations> = null, param4:Vector.<GameRolePlayActorInformations> = null, param5:Vector.<InteractiveElement> = null, param6:Vector.<StatedElement> = null, param7:Vector.<MapObstacle> = null, param8:Vector.<FightCommonInformations> = null, param9:Boolean = false, param10:FightStartingPositions = null, param11:HouseInformationsInside = null) : MapComplementaryInformationsDataInHouseMessage
      {
         super.initMapComplementaryInformationsDataMessage(param1,param2,param3,param4,param5,param6,param7,param8,param9,param10);
         this.currentHouse = param11;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.currentHouse = new HouseInformationsInside();
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
         this.serializeAs_MapComplementaryInformationsDataInHouseMessage(param1);
      }
      
      public function serializeAs_MapComplementaryInformationsDataInHouseMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_MapComplementaryInformationsDataMessage(param1);
         this.currentHouse.serializeAs_HouseInformationsInside(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MapComplementaryInformationsDataInHouseMessage(param1);
      }
      
      public function deserializeAs_MapComplementaryInformationsDataInHouseMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.currentHouse = new HouseInformationsInside();
         this.currentHouse.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MapComplementaryInformationsDataInHouseMessage(param1);
      }
      
      public function deserializeAsyncAs_MapComplementaryInformationsDataInHouseMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._currentHousetree = param1.addChild(this._currentHousetreeFunc);
      }
      
      private function _currentHousetreeFunc(param1:ICustomDataInput) : void
      {
         this.currentHouse = new HouseInformationsInside();
         this.currentHouse.deserializeAsync(this._currentHousetree);
      }
   }
}
