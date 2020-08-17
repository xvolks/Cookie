package com.ankamagames.dofus.network.messages.game.context.roleplay.houses
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.house.HouseInstanceInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class HousePropertiesMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5734;
       
      
      private var _isInitialized:Boolean = false;
      
      public var houseId:uint = 0;
      
      public var doorsOnMap:Vector.<uint>;
      
      public var properties:HouseInstanceInformations;
      
      private var _doorsOnMaptree:FuncTree;
      
      private var _propertiestree:FuncTree;
      
      public function HousePropertiesMessage()
      {
         this.doorsOnMap = new Vector.<uint>();
         this.properties = new HouseInstanceInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5734;
      }
      
      public function initHousePropertiesMessage(param1:uint = 0, param2:Vector.<uint> = null, param3:HouseInstanceInformations = null) : HousePropertiesMessage
      {
         this.houseId = param1;
         this.doorsOnMap = param2;
         this.properties = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.houseId = 0;
         this.doorsOnMap = new Vector.<uint>();
         this.properties = new HouseInstanceInformations();
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
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HousePropertiesMessage(param1);
      }
      
      public function serializeAs_HousePropertiesMessage(param1:ICustomDataOutput) : void
      {
         if(this.houseId < 0)
         {
            throw new Error("Forbidden value (" + this.houseId + ") on element houseId.");
         }
         param1.writeVarInt(this.houseId);
         param1.writeShort(this.doorsOnMap.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.doorsOnMap.length)
         {
            if(this.doorsOnMap[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.doorsOnMap[_loc2_] + ") on element 2 (starting at 1) of doorsOnMap.");
            }
            param1.writeInt(this.doorsOnMap[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.properties.getTypeId());
         this.properties.serialize(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HousePropertiesMessage(param1);
      }
      
      public function deserializeAs_HousePropertiesMessage(param1:ICustomDataInput) : void
      {
         var _loc5_:uint = 0;
         this._houseIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc5_ = param1.readInt();
            if(_loc5_ < 0)
            {
               throw new Error("Forbidden value (" + _loc5_ + ") on elements of doorsOnMap.");
            }
            this.doorsOnMap.push(_loc5_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         this.properties = ProtocolTypeManager.getInstance(HouseInstanceInformations,_loc4_);
         this.properties.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HousePropertiesMessage(param1);
      }
      
      public function deserializeAsyncAs_HousePropertiesMessage(param1:FuncTree) : void
      {
         param1.addChild(this._houseIdFunc);
         this._doorsOnMaptree = param1.addChild(this._doorsOnMaptreeFunc);
         this._propertiestree = param1.addChild(this._propertiestreeFunc);
      }
      
      private function _houseIdFunc(param1:ICustomDataInput) : void
      {
         this.houseId = param1.readVarUhInt();
         if(this.houseId < 0)
         {
            throw new Error("Forbidden value (" + this.houseId + ") on element of HousePropertiesMessage.houseId.");
         }
      }
      
      private function _doorsOnMaptreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._doorsOnMaptree.addChild(this._doorsOnMapFunc);
            _loc3_++;
         }
      }
      
      private function _doorsOnMapFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readInt();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of doorsOnMap.");
         }
         this.doorsOnMap.push(_loc2_);
      }
      
      private function _propertiestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.properties = ProtocolTypeManager.getInstance(HouseInstanceInformations,_loc2_);
         this.properties.deserializeAsync(this._propertiestree);
      }
   }
}
