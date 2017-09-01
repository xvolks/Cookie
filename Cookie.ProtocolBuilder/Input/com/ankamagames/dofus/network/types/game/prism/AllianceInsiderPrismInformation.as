package com.ankamagames.dofus.network.types.game.prism
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItem;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class AllianceInsiderPrismInformation extends PrismInformation implements INetworkType
   {
      
      public static const protocolId:uint = 431;
       
      
      public var lastTimeSlotModificationDate:uint = 0;
      
      public var lastTimeSlotModificationAuthorGuildId:uint = 0;
      
      public var lastTimeSlotModificationAuthorId:Number = 0;
      
      public var lastTimeSlotModificationAuthorName:String = "";
      
      public var modulesObjects:Vector.<ObjectItem>;
      
      private var _modulesObjectstree:FuncTree;
      
      public function AllianceInsiderPrismInformation()
      {
         this.modulesObjects = new Vector.<ObjectItem>();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 431;
      }
      
      public function initAllianceInsiderPrismInformation(param1:uint = 0, param2:uint = 1, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:uint = 0, param7:uint = 0, param8:Number = 0, param9:String = "", param10:Vector.<ObjectItem> = null) : AllianceInsiderPrismInformation
      {
         super.initPrismInformation(param1,param2,param3,param4,param5);
         this.lastTimeSlotModificationDate = param6;
         this.lastTimeSlotModificationAuthorGuildId = param7;
         this.lastTimeSlotModificationAuthorId = param8;
         this.lastTimeSlotModificationAuthorName = param9;
         this.modulesObjects = param10;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.lastTimeSlotModificationDate = 0;
         this.lastTimeSlotModificationAuthorGuildId = 0;
         this.lastTimeSlotModificationAuthorId = 0;
         this.lastTimeSlotModificationAuthorName = "";
         this.modulesObjects = new Vector.<ObjectItem>();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AllianceInsiderPrismInformation(param1);
      }
      
      public function serializeAs_AllianceInsiderPrismInformation(param1:ICustomDataOutput) : void
      {
         super.serializeAs_PrismInformation(param1);
         if(this.lastTimeSlotModificationDate < 0)
         {
            throw new Error("Forbidden value (" + this.lastTimeSlotModificationDate + ") on element lastTimeSlotModificationDate.");
         }
         param1.writeInt(this.lastTimeSlotModificationDate);
         if(this.lastTimeSlotModificationAuthorGuildId < 0)
         {
            throw new Error("Forbidden value (" + this.lastTimeSlotModificationAuthorGuildId + ") on element lastTimeSlotModificationAuthorGuildId.");
         }
         param1.writeVarInt(this.lastTimeSlotModificationAuthorGuildId);
         if(this.lastTimeSlotModificationAuthorId < 0 || this.lastTimeSlotModificationAuthorId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.lastTimeSlotModificationAuthorId + ") on element lastTimeSlotModificationAuthorId.");
         }
         param1.writeVarLong(this.lastTimeSlotModificationAuthorId);
         param1.writeUTF(this.lastTimeSlotModificationAuthorName);
         param1.writeShort(this.modulesObjects.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.modulesObjects.length)
         {
            (this.modulesObjects[_loc2_] as ObjectItem).serializeAs_ObjectItem(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceInsiderPrismInformation(param1);
      }
      
      public function deserializeAs_AllianceInsiderPrismInformation(param1:ICustomDataInput) : void
      {
         var _loc4_:ObjectItem = null;
         super.deserialize(param1);
         this._lastTimeSlotModificationDateFunc(param1);
         this._lastTimeSlotModificationAuthorGuildIdFunc(param1);
         this._lastTimeSlotModificationAuthorIdFunc(param1);
         this._lastTimeSlotModificationAuthorNameFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ObjectItem();
            _loc4_.deserialize(param1);
            this.modulesObjects.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceInsiderPrismInformation(param1);
      }
      
      public function deserializeAsyncAs_AllianceInsiderPrismInformation(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._lastTimeSlotModificationDateFunc);
         param1.addChild(this._lastTimeSlotModificationAuthorGuildIdFunc);
         param1.addChild(this._lastTimeSlotModificationAuthorIdFunc);
         param1.addChild(this._lastTimeSlotModificationAuthorNameFunc);
         this._modulesObjectstree = param1.addChild(this._modulesObjectstreeFunc);
      }
      
      private function _lastTimeSlotModificationDateFunc(param1:ICustomDataInput) : void
      {
         this.lastTimeSlotModificationDate = param1.readInt();
         if(this.lastTimeSlotModificationDate < 0)
         {
            throw new Error("Forbidden value (" + this.lastTimeSlotModificationDate + ") on element of AllianceInsiderPrismInformation.lastTimeSlotModificationDate.");
         }
      }
      
      private function _lastTimeSlotModificationAuthorGuildIdFunc(param1:ICustomDataInput) : void
      {
         this.lastTimeSlotModificationAuthorGuildId = param1.readVarUhInt();
         if(this.lastTimeSlotModificationAuthorGuildId < 0)
         {
            throw new Error("Forbidden value (" + this.lastTimeSlotModificationAuthorGuildId + ") on element of AllianceInsiderPrismInformation.lastTimeSlotModificationAuthorGuildId.");
         }
      }
      
      private function _lastTimeSlotModificationAuthorIdFunc(param1:ICustomDataInput) : void
      {
         this.lastTimeSlotModificationAuthorId = param1.readVarUhLong();
         if(this.lastTimeSlotModificationAuthorId < 0 || this.lastTimeSlotModificationAuthorId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.lastTimeSlotModificationAuthorId + ") on element of AllianceInsiderPrismInformation.lastTimeSlotModificationAuthorId.");
         }
      }
      
      private function _lastTimeSlotModificationAuthorNameFunc(param1:ICustomDataInput) : void
      {
         this.lastTimeSlotModificationAuthorName = param1.readUTF();
      }
      
      private function _modulesObjectstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._modulesObjectstree.addChild(this._modulesObjectsFunc);
            _loc3_++;
         }
      }
      
      private function _modulesObjectsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItem = new ObjectItem();
         _loc2_.deserialize(param1);
         this.modulesObjects.push(_loc2_);
      }
   }
}
