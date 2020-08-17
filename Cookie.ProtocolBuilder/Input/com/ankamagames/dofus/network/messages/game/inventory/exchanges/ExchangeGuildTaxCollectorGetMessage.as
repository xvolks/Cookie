package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItemGenericQuantity;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeGuildTaxCollectorGetMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5762;
       
      
      private var _isInitialized:Boolean = false;
      
      public var collectorName:String = "";
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public var mapId:int = 0;
      
      public var subAreaId:uint = 0;
      
      public var userName:String = "";
      
      public var callerId:Number = 0;
      
      public var callerName:String = "";
      
      public var experience:Number = 0;
      
      public var pods:uint = 0;
      
      public var objectsInfos:Vector.<ObjectItemGenericQuantity>;
      
      private var _objectsInfostree:FuncTree;
      
      public function ExchangeGuildTaxCollectorGetMessage()
      {
         this.objectsInfos = new Vector.<ObjectItemGenericQuantity>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5762;
      }
      
      public function initExchangeGuildTaxCollectorGetMessage(param1:String = "", param2:int = 0, param3:int = 0, param4:int = 0, param5:uint = 0, param6:String = "", param7:Number = 0, param8:String = "", param9:Number = 0, param10:uint = 0, param11:Vector.<ObjectItemGenericQuantity> = null) : ExchangeGuildTaxCollectorGetMessage
      {
         this.collectorName = param1;
         this.worldX = param2;
         this.worldY = param3;
         this.mapId = param4;
         this.subAreaId = param5;
         this.userName = param6;
         this.callerId = param7;
         this.callerName = param8;
         this.experience = param9;
         this.pods = param10;
         this.objectsInfos = param11;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.collectorName = "";
         this.worldX = 0;
         this.worldY = 0;
         this.mapId = 0;
         this.subAreaId = 0;
         this.userName = "";
         this.callerId = 0;
         this.callerName = "";
         this.experience = 0;
         this.pods = 0;
         this.objectsInfos = new Vector.<ObjectItemGenericQuantity>();
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
         this.serializeAs_ExchangeGuildTaxCollectorGetMessage(param1);
      }
      
      public function serializeAs_ExchangeGuildTaxCollectorGetMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.collectorName);
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
         param1.writeInt(this.mapId);
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element subAreaId.");
         }
         param1.writeVarShort(this.subAreaId);
         param1.writeUTF(this.userName);
         if(this.callerId < 0 || this.callerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.callerId + ") on element callerId.");
         }
         param1.writeVarLong(this.callerId);
         param1.writeUTF(this.callerName);
         if(this.experience < -9007199254740990 || this.experience > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experience + ") on element experience.");
         }
         param1.writeDouble(this.experience);
         if(this.pods < 0)
         {
            throw new Error("Forbidden value (" + this.pods + ") on element pods.");
         }
         param1.writeVarShort(this.pods);
         param1.writeShort(this.objectsInfos.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.objectsInfos.length)
         {
            (this.objectsInfos[_loc2_] as ObjectItemGenericQuantity).serializeAs_ObjectItemGenericQuantity(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeGuildTaxCollectorGetMessage(param1);
      }
      
      public function deserializeAs_ExchangeGuildTaxCollectorGetMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:ObjectItemGenericQuantity = null;
         this._collectorNameFunc(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
         this._mapIdFunc(param1);
         this._subAreaIdFunc(param1);
         this._userNameFunc(param1);
         this._callerIdFunc(param1);
         this._callerNameFunc(param1);
         this._experienceFunc(param1);
         this._podsFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ObjectItemGenericQuantity();
            _loc4_.deserialize(param1);
            this.objectsInfos.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeGuildTaxCollectorGetMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeGuildTaxCollectorGetMessage(param1:FuncTree) : void
      {
         param1.addChild(this._collectorNameFunc);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
         param1.addChild(this._mapIdFunc);
         param1.addChild(this._subAreaIdFunc);
         param1.addChild(this._userNameFunc);
         param1.addChild(this._callerIdFunc);
         param1.addChild(this._callerNameFunc);
         param1.addChild(this._experienceFunc);
         param1.addChild(this._podsFunc);
         this._objectsInfostree = param1.addChild(this._objectsInfostreeFunc);
      }
      
      private function _collectorNameFunc(param1:ICustomDataInput) : void
      {
         this.collectorName = param1.readUTF();
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of ExchangeGuildTaxCollectorGetMessage.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of ExchangeGuildTaxCollectorGetMessage.worldY.");
         }
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of ExchangeGuildTaxCollectorGetMessage.subAreaId.");
         }
      }
      
      private function _userNameFunc(param1:ICustomDataInput) : void
      {
         this.userName = param1.readUTF();
      }
      
      private function _callerIdFunc(param1:ICustomDataInput) : void
      {
         this.callerId = param1.readVarUhLong();
         if(this.callerId < 0 || this.callerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.callerId + ") on element of ExchangeGuildTaxCollectorGetMessage.callerId.");
         }
      }
      
      private function _callerNameFunc(param1:ICustomDataInput) : void
      {
         this.callerName = param1.readUTF();
      }
      
      private function _experienceFunc(param1:ICustomDataInput) : void
      {
         this.experience = param1.readDouble();
         if(this.experience < -9007199254740990 || this.experience > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experience + ") on element of ExchangeGuildTaxCollectorGetMessage.experience.");
         }
      }
      
      private function _podsFunc(param1:ICustomDataInput) : void
      {
         this.pods = param1.readVarUhShort();
         if(this.pods < 0)
         {
            throw new Error("Forbidden value (" + this.pods + ") on element of ExchangeGuildTaxCollectorGetMessage.pods.");
         }
      }
      
      private function _objectsInfostreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._objectsInfostree.addChild(this._objectsInfosFunc);
            _loc3_++;
         }
      }
      
      private function _objectsInfosFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItemGenericQuantity = new ObjectItemGenericQuantity();
         _loc2_.deserialize(param1);
         this.objectsInfos.push(_loc2_);
      }
   }
}
