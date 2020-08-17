package com.ankamagames.dofus.network.messages.game.guild.tax
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.guild.tax.TaxCollectorInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AbstractTaxCollectorListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6568;
       
      
      private var _isInitialized:Boolean = false;
      
      public var informations:Vector.<TaxCollectorInformations>;
      
      private var _informationstree:FuncTree;
      
      public function AbstractTaxCollectorListMessage()
      {
         this.informations = new Vector.<TaxCollectorInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6568;
      }
      
      public function initAbstractTaxCollectorListMessage(param1:Vector.<TaxCollectorInformations> = null) : AbstractTaxCollectorListMessage
      {
         this.informations = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.informations = new Vector.<TaxCollectorInformations>();
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
         this.serializeAs_AbstractTaxCollectorListMessage(param1);
      }
      
      public function serializeAs_AbstractTaxCollectorListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.informations.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.informations.length)
         {
            param1.writeShort((this.informations[_loc2_] as TaxCollectorInformations).getTypeId());
            (this.informations[_loc2_] as TaxCollectorInformations).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AbstractTaxCollectorListMessage(param1);
      }
      
      public function deserializeAs_AbstractTaxCollectorListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:TaxCollectorInformations = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(TaxCollectorInformations,_loc4_);
            _loc5_.deserialize(param1);
            this.informations.push(_loc5_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AbstractTaxCollectorListMessage(param1);
      }
      
      public function deserializeAsyncAs_AbstractTaxCollectorListMessage(param1:FuncTree) : void
      {
         this._informationstree = param1.addChild(this._informationstreeFunc);
      }
      
      private function _informationstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._informationstree.addChild(this._informationsFunc);
            _loc3_++;
         }
      }
      
      private function _informationsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:TaxCollectorInformations = ProtocolTypeManager.getInstance(TaxCollectorInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.informations.push(_loc3_);
      }
   }
}
