package com.ankamagames.dofus.network.messages.game.context.roleplay
{
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
   public class MapComplementaryInformationsWithCoordsMessage extends MapComplementaryInformationsDataMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6268;
       
      
      private var _isInitialized:Boolean = false;
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public function MapComplementaryInformationsWithCoordsMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6268;
      }
      
      public function initMapComplementaryInformationsWithCoordsMessage(param1:uint = 0, param2:uint = 0, param3:Vector.<HouseInformations> = null, param4:Vector.<GameRolePlayActorInformations> = null, param5:Vector.<InteractiveElement> = null, param6:Vector.<StatedElement> = null, param7:Vector.<MapObstacle> = null, param8:Vector.<FightCommonInformations> = null, param9:Boolean = false, param10:FightStartingPositions = null, param11:int = 0, param12:int = 0) : MapComplementaryInformationsWithCoordsMessage
      {
         super.initMapComplementaryInformationsDataMessage(param1,param2,param3,param4,param5,param6,param7,param8,param9,param10);
         this.worldX = param11;
         this.worldY = param12;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.worldX = 0;
         this.worldY = 0;
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
         this.serializeAs_MapComplementaryInformationsWithCoordsMessage(param1);
      }
      
      public function serializeAs_MapComplementaryInformationsWithCoordsMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_MapComplementaryInformationsDataMessage(param1);
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element worldX.");
         }
         param1.writeShort(this.worldX);
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element worldY.");
         }
         param1.writeShort(this.worldY);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MapComplementaryInformationsWithCoordsMessage(param1);
      }
      
      public function deserializeAs_MapComplementaryInformationsWithCoordsMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MapComplementaryInformationsWithCoordsMessage(param1);
      }
      
      public function deserializeAsyncAs_MapComplementaryInformationsWithCoordsMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of MapComplementaryInformationsWithCoordsMessage.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of MapComplementaryInformationsWithCoordsMessage.worldY.");
         }
      }
   }
}
