package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GroupMonsterStaticInformations implements INetworkType
   {
      
      public static const protocolId:uint = 140;
       
      
      public var mainCreatureLightInfos:MonsterInGroupLightInformations;
      
      public var underlings:Vector.<MonsterInGroupInformations>;
      
      private var _mainCreatureLightInfostree:FuncTree;
      
      private var _underlingstree:FuncTree;
      
      public function GroupMonsterStaticInformations()
      {
         this.mainCreatureLightInfos = new MonsterInGroupLightInformations();
         this.underlings = new Vector.<MonsterInGroupInformations>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 140;
      }
      
      public function initGroupMonsterStaticInformations(param1:MonsterInGroupLightInformations = null, param2:Vector.<MonsterInGroupInformations> = null) : GroupMonsterStaticInformations
      {
         this.mainCreatureLightInfos = param1;
         this.underlings = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.mainCreatureLightInfos = new MonsterInGroupLightInformations();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GroupMonsterStaticInformations(param1);
      }
      
      public function serializeAs_GroupMonsterStaticInformations(param1:ICustomDataOutput) : void
      {
         this.mainCreatureLightInfos.serializeAs_MonsterInGroupLightInformations(param1);
         param1.writeShort(this.underlings.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.underlings.length)
         {
            (this.underlings[_loc2_] as MonsterInGroupInformations).serializeAs_MonsterInGroupInformations(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GroupMonsterStaticInformations(param1);
      }
      
      public function deserializeAs_GroupMonsterStaticInformations(param1:ICustomDataInput) : void
      {
         var _loc4_:MonsterInGroupInformations = null;
         this.mainCreatureLightInfos = new MonsterInGroupLightInformations();
         this.mainCreatureLightInfos.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new MonsterInGroupInformations();
            _loc4_.deserialize(param1);
            this.underlings.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GroupMonsterStaticInformations(param1);
      }
      
      public function deserializeAsyncAs_GroupMonsterStaticInformations(param1:FuncTree) : void
      {
         this._mainCreatureLightInfostree = param1.addChild(this._mainCreatureLightInfostreeFunc);
         this._underlingstree = param1.addChild(this._underlingstreeFunc);
      }
      
      private function _mainCreatureLightInfostreeFunc(param1:ICustomDataInput) : void
      {
         this.mainCreatureLightInfos = new MonsterInGroupLightInformations();
         this.mainCreatureLightInfos.deserializeAsync(this._mainCreatureLightInfostree);
      }
      
      private function _underlingstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._underlingstree.addChild(this._underlingsFunc);
            _loc3_++;
         }
      }
      
      private function _underlingsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:MonsterInGroupInformations = new MonsterInGroupInformations();
         _loc2_.deserialize(param1);
         this.underlings.push(_loc2_);
      }
   }
}
